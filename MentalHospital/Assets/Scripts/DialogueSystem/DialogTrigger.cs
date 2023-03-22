using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialogue;

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogManager>().StartDialogue(dialogue);
    }
}
