using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerRoom : MonoBehaviour {

    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;

    public Button choiceOne;
    public Button choiceTwo;
    public Button continueButton;

    private int counter = 0;

    public Animator animator;
    // Use this for initialization
    void Start()
    {

    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text = dialogueText.text + letter;
            yield return null;
        }
    }
}
