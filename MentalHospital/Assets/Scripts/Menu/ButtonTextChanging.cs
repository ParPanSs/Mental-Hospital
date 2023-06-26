using System.Linq;
using GameToolkit.Localization;
using TMPro;
using UnityEngine;

public class ButtonTextChanging : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown languageDropdown;
    [SerializeField] private string[] languages;

    private void Start()
    {
        int currentLanguageIndex = 0;
        languageDropdown.captionText.text = PlayerPrefs.GetString("GameLanguage");
        for (int i = 0; i < languages.Length; i++)
        {
            if (languages[i] == languageDropdown.captionText.text)
            {
                currentLanguageIndex = i;
            }
        }
        languageDropdown.value = currentLanguageIndex;
        languageDropdown.RefreshShownValue();
    }

    public void ChangeLanguage()
    {
        PlayerPrefs.SetString("GameLanguage", languageDropdown.captionText.text);
        PlayerPrefs.Save();
        var language = GetSavedLanguage();
        if (language != Language.Unknown)
        {
            Localization.Instance.CurrentLanguage = language;
        }
    }
    
    private Language GetSavedLanguage()
    {
        if (PlayerPrefs.HasKey("GameLanguage"))
        {
            var languageCode = PlayerPrefs.GetString("GameLanguage", "");
            var language = 
                LocalizationSettings.Instance.AvailableLanguages.FirstOrDefault(x => x.Code == languageCode);
            if (language != null)
            {
                return language;
            }
        }

        return Language.Unknown;
    }
}
