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

    void Update()
    {
        if (rationalCounter.text == "3/3" || irrationalCounter.text == "3/3")
        {
            PlayerPrefs.SetInt("DayCounter", PlayerPrefs.GetInt("DayCounter") + 1);
            if (rationalCounter.text == "3/3")
                Behaviour.rational = true;
            SceneManager.LoadScene(PlayerPrefs.GetInt("DayCounter") + 1);
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
}
