using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetInt("DayCounter", 0);
        SceneManager.LoadScene(PlayerPrefs.GetInt("DayCounter") + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
