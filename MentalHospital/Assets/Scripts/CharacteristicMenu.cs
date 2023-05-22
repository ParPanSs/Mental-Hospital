using UnityEngine;

public class CharacteristicMenu : MonoBehaviour
{
    private bool _isPaused;
    private void Update()
    {
        if (_isPaused)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }

    public void SetPause()
    {
        _isPaused = !_isPaused;
    }
}
