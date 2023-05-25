using System.Collections;
using System.Collections.Generic;
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

    [SerializeField] private TextAsset loadGlobalsJSON;

    [SerializeField] private GameObject dialoguePanel;

    [SerializeField] private TextMeshProUGUI dialogueText;

    [SerializeField] private GameObject[] choices;
    [SerializeField] private GameObject choicesBackground;
    [SerializeField] private Animator choicesAnimator;
    [SerializeField] private Animator portraitAnimator;
    [SerializeField] private ItemPickup itemPickup;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private LayerMask whatIsItem;
    
    private TextMeshProUGUI[] choicesText;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }

    private bool canContinueToNextLine = false;

    private Coroutine displayLineCoroutine;

    private DialogueVariables dialogueVariables;

    private static DialogManager instance;

    [SerializeField] private Animator endOfTheDay;

    private const string PORTRAIT_TAG = "portrait";

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
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
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
            ExitDialogueMode();
            dialogueVariables.SaveVariables();
            StartCoroutine(StartNextDay(dayIndex));
        });
        
        currentStory.BindExternalFunction("pickUpItem", () =>
        {
            RaycastHit2D ray = Physics2D.Raycast(player.transform.position, Vector2.up, 100f, whatIsItem);
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
        });
        
        currentStory.BindExternalFunction("callBus", () =>
        {
            FindObjectOfType<Bus>().enabled = true;
        });
        
        currentStory.BindExternalFunction("offCollider", () =>
        {
            gameObject.transform.GetComponent<BoxCollider2D>().enabled = false;
        });

        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        currentStory.UnbindExternalFunction("finishDay");
        currentStory.UnbindExternalFunction("language");
        currentStory.UnbindExternalFunction("pickUpItem");
        currentStory.UnbindExternalFunction("blockChoice");
        currentStory.UnbindExternalFunction("callBus");
        currentStory.UnbindExternalFunction("offCollider");

        foreach (var choice in choices)
        {
            choice.gameObject.GetComponent<Button>().interactable = true;
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
