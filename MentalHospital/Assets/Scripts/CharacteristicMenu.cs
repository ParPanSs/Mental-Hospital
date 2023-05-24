using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CharacteristicMenu : MonoBehaviour
{
    private bool _isPaused;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject characteristicMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !characteristicMenu.activeInHierarchy)
        {
            _isPaused = !_isPaused;
            pauseMenu.SetActive(_isPaused);
        }
        if(_isPaused)
        {
            Time.timeScale = 0f;
            Camera.main.GetComponent<PostProcessVolume>().enabled = true;
        }
        else if(!_isPaused && !DialogManager.GetInstance().dialogueIsPlaying)
        {
            Time.timeScale = 1f;
            Camera.main.GetComponent<PostProcessVolume>().enabled = false;
        }
    }

    public void SetPause()
    {
        _isPaused = !_isPaused;
    }
}
