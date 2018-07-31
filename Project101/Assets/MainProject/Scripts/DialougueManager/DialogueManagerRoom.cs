using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManagerRoom : MonoBehaviour
{
    private Queue<string> questions = new Queue<string>();

    public Text nameText;
    public Text dialogueText;

    public Button choiceOne;
    public Button choiceTwo;
    public Button continueButton;

    private int counter = 0;

    public Animator animator;
    public Animator hintBox;

    // Use this for initialization
    void Start()
    {

    }

    public void StartDialogueRoom(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        questions.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            questions.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (questions.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = questions.Dequeue();

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
