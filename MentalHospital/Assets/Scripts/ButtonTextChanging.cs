using System.Linq;
using GameToolkit.Localization;
using TMPro;
using UnityEngine;

public class ButtonTextChanging : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    private void Start()
    {
        //dropdown.value = PlayerPrefs.GetString("GameLanguage");
        dropdown.captionText.text = PlayerPrefs.GetString("GameLanguage");
    }

    public void ChangeLanguage()
    {
        PlayerPrefs.SetString("GameLanguage", dropdown.captionText.text);
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
