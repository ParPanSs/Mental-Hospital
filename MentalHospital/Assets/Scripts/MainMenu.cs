using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        if (PlayerPrefs.HasKey("GameLanguage"))
        {
            PlayerPrefs.GetString("GameLanguage", "");
        }
        else
        {
            PlayerPrefs.SetString("GameLanguage", "en");
        }
    }
    public void PlayGame()
    {
        PlayerPrefs.SetInt("DayCounter", 1);
        PlayerPrefs.DeleteKey("INK_VARIABLES");
        PlayerPrefs.Save();
        SceneManager.LoadScene(PlayerPrefs.GetInt("DayCounter"));
    }

    public void ContinueGame()
    {
        if(PlayerPrefs.HasKey("DayCounter"))
            SceneManager.LoadScene(PlayerPrefs.GetInt("DayCounter"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
