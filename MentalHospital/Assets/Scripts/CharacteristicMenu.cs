using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CharacteristicMenu : MonoBehaviour
{
    private bool _isPaused;
    private void Update()
    {
        if (_isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void SetPause()
    {
        if (!Camera.main.GetComponent<PostProcessVolume>().enabled)
        {
            Camera.main.GetComponent<PostProcessVolume>().enabled = true;
        }
        else
        {
            Camera.main.GetComponent<PostProcessVolume>().enabled = false;
        }
        _isPaused = !_isPaused;
    }
}
