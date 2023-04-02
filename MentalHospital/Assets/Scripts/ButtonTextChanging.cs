using GameToolkit.Localization;
using TMPro;
using UnityEngine;

public class ButtonTextChanging : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public TextMeshProUGUI button_text;
    public TextMeshProUGUI sampleText;
    public TextMeshProUGUI greetings;
    public LocalizedText[] text;
    public void Update()
    {
        switch (dropdown.captionText.text)
        {
            case "English":
                button_text.text = text[0].LocaleItems[0].ObjectValue.ToString();
                sampleText.text = text[1].LocaleItems[0].ObjectValue.ToString();
                greetings.text = text[2].LocaleItems[0].ObjectValue.ToString();
                break;
            case "Czech":
                button_text.text = text[0].LocaleItems[1].ObjectValue.ToString();
                sampleText.text = text[1].LocaleItems[1].ObjectValue.ToString();
                greetings.text = text[2].LocaleItems[1].ObjectValue.ToString();
                break;
            case "Russian":
                button_text.text = text[0].LocaleItems[2].ObjectValue.ToString();
                sampleText.text = text[1].LocaleItems[2].ObjectValue.ToString();
                greetings.text = text[2].LocaleItems[2].ObjectValue.ToString();
                break;
        }
    }
}
