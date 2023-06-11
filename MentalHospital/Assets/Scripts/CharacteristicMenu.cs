using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class CharacteristicMenu : MonoBehaviour
{
    private bool _isPaused;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject characteristicMenu;
    [SerializeField] private GameObject inventoryMenu;
    [SerializeField] private GameObject helperMenu;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !characteristicMenu.activeInHierarchy && !inventoryMenu.activeInHierarchy &&
            !DialogManager.GetInstance().dialogueIsPlaying)
        {
            _isPaused = !_isPaused;
            pauseMenu.SetActive(_isPaused);
            helperMenu.SetActive(!_isPaused);
        }

        if (Input.GetKeyDown(KeyCode.I) && !characteristicMenu.activeInHierarchy && !pauseMenu.activeInHierarchy &&
            !DialogManager.GetInstance().dialogueIsPlaying)
        {
            _isPaused = !_isPaused;
            inventoryMenu.SetActive(_isPaused);
            helperMenu.SetActive(!_isPaused);
            InventoryManager.GetInstance().ListItems();
        }
        
        if (Input.GetKeyDown(KeyCode.C) && !inventoryMenu.activeInHierarchy && !pauseMenu.activeInHierarchy &&
            !DialogManager.GetInstance().dialogueIsPlaying)
        {
            _isPaused = !_isPaused;
            characteristicMenu.SetActive(_isPaused);
            helperMenu.SetActive(!_isPaused);
        }
        if(_isPaused || inventoryMenu.activeInHierarchy || characteristicMenu.activeInHierarchy)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        else
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void SetPause()
    {
        _isPaused = !_isPaused;
        Camera.main.GetComponent<PostProcessVolume>().enabled = _isPaused;
    }
}
