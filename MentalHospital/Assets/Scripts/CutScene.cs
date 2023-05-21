using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CutScene : MonoBehaviour
{
    private void Start()
    {
        PlayerPrefs.SetInt("DayCounter", SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {
        if (!gameObject.GetComponent<VideoPlayer>().isPlaying)
            SceneManager.LoadScene(PlayerPrefs.GetInt("DayCounter") + 1);
    }
}
