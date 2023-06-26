using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Ink.Runtime;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    private float typingSpeed = 0.04f;

    [Header("Dialogue Panel")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;
    
    [Header("Choices")]
    [SerializeField] private GameObject[] choices;
    [SerializeField] private GameObject choicesBackground;
    [SerializeField] private Animator choicesAnimator;
    
    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private ItemPickup itemPickup;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private LayerMask whatIsItem;

    [Header("Postcards")] 
    [SerializeField] private GameObject[] cards;
    [SerializeField] private Sprite[] images;
    
    private TextMeshProUGUI[] choicesText;

    public Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;

    private DialogueVariables dialogueVariables;

    private static DialogManager instance;

    [SerializeField] private Animator endOfTheDay;

    private const string PORTRAIT_TAG = "portrait";

    private Behaviour _behaviour;

    [SerializeField] private TMP_FontAsset readableFont;
    [SerializeField] private TMP_FontAsset unreadableFont;

    private void Awake()
    {
        instance = this;

        dialogueVariables = new DialogueVariables(loadGlobalsJSON);
    }

    public static DialogManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        _behaviour = FindObjectOfType<Behaviour>();
        //dialogueIsPlaying = false;
        //dialoguePanel.SetActive(false);
        choicesBackground.SetActive(false);
        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }

    private void Update()
    {
        if (!dialogueIsPlaying)
            return;

        if (canContinueToNextLine && currentStory.currentChoices.Count == 0 && Input.GetKeyDown(KeyCode.Return))
        {
            ContinueStory();
        }
        if (choicesAnimator.GetCurrentAnimatorStateInfo(0).IsName("ChoicesExit"))
        {
            choicesBackground.SetActive(false);
        }
    }

    public void EnterDialogueMode(TextAsset inkJSON, GameObject gameObject)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogueVariables.StartListening(currentStory);

        currentStory.BindExternalFunction("language", (string currentLanguage) =>
        {
            if (currentLanguage != null)
            {
                currentLanguage = PlayerPrefs.GetString("GameLanguage");
            }

            return currentLanguage;
        });
        currentStory.BindExternalFunction("finishDay", () =>
        {
            var dayIndex = PlayerPrefs.GetInt("DayCounter") + 1;
            endOfTheDay.SetBool("fader_in", true);
            dialogueVariables.SaveVariables();
            StartCoroutine(StartNextDay(dayIndex));
        });
        
        currentStory.BindExternalFunction("pickUpItem", () =>
        {
            RaycastHit2D ray = Physics2D.CircleCast(player.transform.position, 5f, Vector2.zero, Mathf.Infinity, whatIsItem);
            if (ray.collider != null)
            {
                Debug.Log("Touched: " + ray.collider.name);
                itemPickup = ray.collider.GetComponent<ItemPickup>();
                itemPickup.PickUp();
            }
        });
        currentStory.BindExternalFunction("blockChoice", (int choiceIndex) =>
        {
            choices[choiceIndex].gameObject.GetComponent<Button>().interactable = false;
            choices[choiceIndex].gameObject.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().font =
                unreadableFont;
        });
        
        
        currentStory.BindExternalFunction("callBus", () =>
        {
            FindObjectOfType<Bus>().enabled = true;
        });
        
        currentStory.BindExternalFunction("offCollider", () =>
        {
            gameObject.transform.GetComponent<Collider2D>().enabled = false;
        });
        
        currentStory.BindExternalFunction("checkCharacteristic", (int characteristicIndex) =>
        {
            var exists = _behaviour.characteristicsList.ElementAtOrDefault(characteristicIndex) != null;
            if (exists)
            {
                return _behaviour.characteristicsList[characteristicIndex].ToString();
            }

            return "empty";
        });
        
        currentStory.BindExternalFunction("firstCard", () =>
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].gameObject.SetActive(true);
                cards[0].gameObject.GetComponent<Image>().sprite = images[0];
                cards[1].gameObject.GetComponent<Image>().sprite = images[1];
                cards[2].gameObject.GetComponent<Image>().sprite = images[2];
            }
        });
        currentStory.BindExternalFunction("secondCard", () =>
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].gameObject.SetActive(true);
                cards[0].gameObject.GetComponent<Image>().sprite = images[3];
                cards[1].gameObject.GetComponent<Image>().sprite = images[4];
                cards[2].gameObject.GetComponent<Image>().sprite = images[5];
            }
        });
        currentStory.BindExternalFunction("thirdCard", () =>
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].gameObject.SetActive(true);

                cards[0].gameObject.GetComponent<Image>().sprite = images[6];
                cards[1].gameObject.GetComponent<Image>().sprite = images[7];
                cards[2].gameObject.GetComponent<Image>().sprite = images[8];
            }
        });
        currentStory.BindExternalFunction("hideCards", () =>
        {
            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].gameObject.SetActive(false);
            }
        });
        
        

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        currentStory.UnbindExternalFunction("language");
        currentStory.UnbindExternalFunction("pickUpItem");
        currentStory.UnbindExternalFunction("blockChoice");
        currentStory.UnbindExternalFunction("callBus");
        currentStory.UnbindExternalFunction("offCollider");
        currentStory.UnbindExternalFunction("checkCharacteristic");

        foreach (var choice in choices)
        {
            choice.gameObject.GetComponent<Button>().interactable = true;
            choice.gameObject.GetComponentInChildren<TextMeshProUGUI>().font = readableFont;
        }
        
        dialogueVariables.StopListening(currentStory);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
    }

    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            foreach (var choice in choices)
            {
                choice.gameObject.GetComponent<Button>().interactable = true;
                choice.gameObject.GetComponentInChildren<TextMeshProUGUI>().font = readableFont;
            }
            if (displayLineCoroutine != null) 
            {
                StopCoroutine(displayLineCoroutine);
            }
            string nextLine = currentStory.Continue();
            // handle case where the last line is an external function
            if (nextLine.Equals("") && !currentStory.canContinue)
            {
                ExitDialogueMode();
            }
            // otherwise, handle the normal case for continuing the story
            else 
            {
                // handle tags
                HandleTags(currentStory.currentTags);
                displayLineCoroutine = StartCoroutine(DisplayLine(nextLine));
            }
        }
        else
        {
            ExitDialogueMode();
        }
    }
    
    private IEnumerator DisplayLine(string line)
    {
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;

        HideChoices();
        
        canContinueToNextLine = false;

        foreach (char letter in line.ToCharArray())
        {
            // if (Input.GetKeyDown(KeyCode.Return))
            // {
            //     dialogueText.maxVisibleCharacters = line.Length;
            //     break;
            // }

            dialogueText.maxVisibleCharacters++;
            yield return new WaitForSeconds(typingSpeed);
        }
        DisplayChoices();
        
        canContinueToNextLine = true;
    }
    
    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
        Camera.main.GetComponent<PostProcessVolume>().enabled = false;
        choicesAnimator.SetBool("isOpen", false);
        //StartCoroutine(CloseChoices());
    }
    
    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');
            if (splitTag.Length != 2)
            {
                Debug.LogWarning("Tag doesn't match the lenght parameter");
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;
            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;
        int index = 0;
        if (currentChoices.Count > 0)
        {
            choicesBackground.SetActive(true);
            Camera.main.GetComponent<PostProcessVolume>().enabled = true;
            player.velocity = new Vector2(0, 0);
            player.gameObject.GetComponent<Animator>().SetBool("isWalk", false);
        }

        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }

        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            ContinueStory();
        }
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink variable was found to be null: " + variableName);
        }

        return variableValue;
    }

    private IEnumerator StartNextDay(int dayIndex)
    {
        ExitDialogueMode();
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(dayIndex);
    }

    public void OnApplicationQuit()
    {
         dialogueVariables.SaveVariables();
    }

    private IEnumerator CloseChoices()
    {
        yield return new WaitForSeconds(3f);
    }
}
