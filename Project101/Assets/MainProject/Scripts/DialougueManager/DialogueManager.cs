using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    private Queue<string> sentences;

    public Text nameText;
    public Text dialogueText;

    public Button yesButton;
    public Button noButton;
    public Button continueButton;

    private int counter = 0;

    public Animator animator;
    // Use this for initialization
    void Start() {
        sentences = new Queue<string>();
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void StartDialogue(Dialogue dialogue, bool isOptional)
    {
        counter = 0;
        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        counter++;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();

        if (sentence.Equals("Mình có nên quay lại lấy cặp không nhỉ ?"))
        {
            yesButton.gameObject.SetActive(true);
            noButton.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(false);
        }

        if (sentence.Equals("Bạn có muốn ra ngoài không ?"))
        {
            GameObject.Find("Main").GetComponent<PlayerInput>().goOut = false;
            yesButton.gameObject.SetActive(true);
            noButton.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(false);

            yesButton.onClick.AddListener(GoOut);
            noButton.onClick.AddListener(EndDialogue);
        }

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence)); 
    }

    public void EndDialogue()
    {
        GameObject.Find("Main").GetComponent<PlayerInput>().goOut = true;
        animator.SetBool("isOpen", false);
    }

    public void GoOut()
    {
        GameObject.Find("Main").GetComponent<PlayerInput>().goOut = true;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text = dialogueText.text + letter;
            yield return null;
        }
    }

    public void GoodOptionDialogue()
    {
        string[] goodOption = { "Mình cũng nghĩ vậy", "Đi ra và tìm người lớn giúp nào." };

        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);

        Dialogue dialogue = new Dialogue();
        dialogue.name = "Ken";
        dialogue.sentences = goodOption;

        GameObject.Find("Main").GetComponent<PlayerInput>().finishedOption = true;
        StartDialogue(dialogue);
    }

    public void BadOptionDialogue()
    {
        string[] badOption = { "Tớ sợ phải vào đó lắm !", "Chúng ta nên tìm người giúp thì hơn !" };

        yesButton.gameObject.SetActive(false);
        noButton.gameObject.SetActive(false);
        continueButton.gameObject.SetActive(true);

        Dialogue dialogue = new Dialogue();
        dialogue.name = "Ken";
        dialogue.sentences = badOption;

        GameObject.Find("Main").GetComponent<PlayerInput>().finishedOption = true;
        StartDialogue(dialogue);
    }
}
