﻿using System.Collections;
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
    public GameObject controller;

    private bool clickable = false;

    // Use this for initialization
    void Start()
    {
        choiceOne.gameObject.SetActive(false);
        choiceTwo.gameObject.SetActive(false);
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

        counter++;

        animator.SetBool("isOpen", true);

        nameText.text = dialogue.name;

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
}
