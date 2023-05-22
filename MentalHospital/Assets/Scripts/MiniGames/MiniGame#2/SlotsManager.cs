using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlotsManager : MonoBehaviour
{
    [SerializeField] private Transform[] slots;
    [SerializeField] private GameObject button;

    [SerializeField] private TextMeshProUGUI rationalCounter;
    [SerializeField] private TextMeshProUGUI irrationalCounter;
    [SerializeField] private RoundsCounter counter;
    [SerializeField] private Animator fader;
    [SerializeField] private Animator rationalCharacteristic;
    [SerializeField] private Animator irrationalCharacteristic;
    [SerializeField] private Animator blackBack;

    private void Start()
    {
        PlayerPrefs.SetInt("DayCounter", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }
    private void Update()
    {
        if (rationalCounter.text == "3/3" || irrationalCounter.text == "3/3")
        {
            blackBack.enabled = true;
            if (rationalCounter.text == "3/3")
            {
                Behaviour.rational = true;
                rationalCharacteristic.enabled = true;
            }
            else
            {
                irrationalCharacteristic.enabled = true;
            }

            StartCoroutine(EndOfMiniGame());
        }
    }
    public void CheckFull()
    {
        var fullSlot = slots.Where(slot => slot.transform.childCount == 1).ToList();
        if (fullSlot.Count == slots.Length && !(rationalCounter.text == "3/3" || irrationalCounter.text == "3/3"))
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }

    public void ClickButton()
    {
        if (slots[0].GetChild(0).name == "Triangle" && slots[1].GetChild(0).name == "Square" 
                                                    && slots[2].GetChild(0).name == "Pentagon")
        {
            rationalCounter.text = counter.rational + "/3";
            counter.rational += 1;
        }
        else
        {
            irrationalCounter.text = counter.irrational + "/3";
            counter.irrational += 1;
        }
        button.SetActive(false);
    }

    private IEnumerator EndOfMiniGame()
    {
        yield return new WaitForSeconds(2f);
        fader.SetBool("fader_in", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(PlayerPrefs.GetInt("DayCounter") + 1);
    }
}
