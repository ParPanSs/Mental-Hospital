using System;
using TMPro;
using UnityEngine;

public class ButtonTextChanging : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public LocalizationPrefs localization;

    public void Start()
    {
        PlayerPrefs.DeleteAll();
    }

    public void Update()
    {
        switch (dropdown.captionText.text)
        {
            case "English":
                break;
            case "Czech":
                PlayerPrefs.SetString("GameLanguage", "cs");
                break;
            case "Russian":
                break;
        }
        Debug.Log(PlayerPrefs.GetString("GameLanguage"));
        Debug.Log(PlayerPrefs.GetString("Language"));
    }
}
