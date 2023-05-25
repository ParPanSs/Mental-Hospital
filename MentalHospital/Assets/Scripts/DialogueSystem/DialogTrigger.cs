using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    private bool playerInRange;
    [SerializeField] public TextAsset inkJSON;

    private void Update()
    {
        if (playerInRange && !DialogManager.GetInstance().dialogueIsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                DialogManager.GetInstance().EnterDialogueMode(inkJSON, gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
