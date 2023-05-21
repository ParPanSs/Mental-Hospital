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

    private void Start()
    {
        PlayerPrefs.SetInt("DayCounter", SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.Save();
    }
    private void Update()
    {
        if (rationalCounter.text == "3/3" || irrationalCounter.text == "3/3")
        {
            if (rationalCounter.text == "3/3")
                Behaviour.rational = true;
            StartCoroutine(EndOfMiniGame());
        }
    }
    public void CheckFull()
    {
        var fullSlot = slots.Where(slot => slot.transform.childCount == 1).ToList();
        if (fullSlot.Count == slots.Length)
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
    }

    private IEnumerator EndOfMiniGame()
    {
        fader.SetBool("fader_in", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(PlayerPrefs.GetInt("DayCounter") + 1);
    }
}
