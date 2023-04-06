using TMPro;
using UnityEngine;

public class ButtonTextChanging : MonoBehaviour
{
    public TMP_Dropdown dropdown;

    public void Update()
    {
        switch (dropdown.captionText.text)
        {
            case "English":
                PlayerPrefs.SetString("GameLanguage", "en");
                PlayerPrefs.GetString("GameLanguage");
                break;
            case "Czech":
                PlayerPrefs.SetString("GameLanguage", "cs");
                PlayerPrefs.GetString("GameLanguage");
                break;
            case "Russian":
                PlayerPrefs.SetString("GameLanguage", "ru");
                PlayerPrefs.GetString("GameLanguage");
                break;
        }
        Debug.Log(PlayerPrefs.GetString("GameLanguage"));
        Debug.Log(PlayerPrefs.GetString("Language"));
    }
}
