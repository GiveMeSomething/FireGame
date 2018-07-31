using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManagerRoom : MonoBehaviour
{
    private Queue<string> questions = new Queue<string>();

    public Text nameText;
    public Text dialogueText;

    public Button choiceOne;
    public Button choiceTwo;
    public Button continueButton;

    private int counter = 0;
    private int questionListSize = 0;

    public Animator animator;
    public Animator hintBox;
    public GameObject controller;

    public AudioSource rightSound;
    public AudioSource wrongSound;

    private bool clickable = false;
    private string currentHint;

    // Use this for initialization
    void Start()
    {
        choiceOne.gameObject.SetActive(false);
        choiceTwo.gameObject.SetActive(false);
    }

    private void Update()
    {
        PlayerStartDialogue player = controller.GetComponent<PlayerStartDialogue>();
        questionListSize = player.questionlist.Count;
    }
    public void StartDialogueRoom(Dialogue dialogue)
    {
        choiceOne.gameObject.SetActive(false);
        choiceTwo.gameObject.SetActive(false);

        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        questions.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            questions.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void StartDialogueRoom(Dialogue dialogue, string rightAnswer, string wrongAnswer, string hint)
    {
        choiceOne.gameObject.SetActive(true);
        choiceTwo.gameObject.SetActive(true);
        continueButton.gameObject.SetActive(false);

        counter++;

        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;
        currentHint = hint;

        choiceOne.GetComponentInChildren<Text>().text = rightAnswer;
        choiceTwo.GetComponentInChildren<Text>().text = wrongAnswer;

        questions.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            questions.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        FindObjectOfType<HintManager>().EndDialogue();
        if(counter == questionListSize - 1)
        {
            SceneManager.LoadScene("CongratScene 1");
        }
        if (questions.Count == 0)
        {
            PlayerStartDialogue dialogue = controller.GetComponent<PlayerStartDialogue>();
            dialogue.NextQuestion(counter);
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

    public void RightAnswer()
    {
        choiceOne.gameObject.SetActive(false);
        choiceTwo.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
        string[] congrat = { "Tốt quá. Bạn trả lời đúng rồi" };

        Dialogue dialogue = new Dialogue();

        dialogue.name = "";
        dialogue.sentences = congrat;

        rightSound.Play();

        FindObjectOfType<HintManager>().StartDialogue(dialogue);
    }

    public void WrongAnswer()
    {
        choiceOne.gameObject.SetActive(false);
        choiceTwo.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
        string[] hint = { currentHint };

        Dialogue dialogue = new Dialogue();

        dialogue.name = "";
        dialogue.sentences = hint;

        wrongSound.Play();

        FindObjectOfType<HintManager>().StartDialogue(dialogue);
    }
}
