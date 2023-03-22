using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    private Queue<string> _sentences;
    public Animator animator;
    void Start()
    {
        _sentences = new Queue<string>();
    }

    public void StartDialogue(Dialog dialogue)
    {
        animator.SetBool("IsOpen", true);
        _sentences.Clear();

        foreach (string sentence in _sentences)
        {        
            Debug.Log(sentence);

            _sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = _sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);

    }
}
