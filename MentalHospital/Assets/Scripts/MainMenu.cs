using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteKey("DayCounter");
        PlayerPrefs.Save();
    }
    public void PlayGame()
    {
        PlayerPrefs.SetInt("DayCounter", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene(PlayerPrefs.GetInt("DayCounter") + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
