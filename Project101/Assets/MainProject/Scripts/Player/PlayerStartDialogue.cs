using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStartDialogue : MonoBehaviour {

    public bool started = false;
    public Button startButton;
    
    private string[] startDialogue = { "Về đến nhà rồi. Mình cùng ôn lại một bài học nhé." };
    ArrayList questionlist = new ArrayList();
    private string[] question1 = { "Q1" };
    private string[] question2 = { "Q2" };
    private string[] rightAnswer = { "rA1", "rA2", "rA3" };
    private string[] wrongAnswer = { "wA1", "wA2", "wA3" };
    private string[] hint = { "h1", "h2", "h3" };
    private int numberQuestions = 0;

    void Start () {
        questionlist.Add(question1);
        questionlist.Add(question2);
	}
	
	// Update is called once per frame
	public void StartDialogue () {
        startButton.gameObject.SetActive(false);
        Dialogue dialogue = new Dialogue();

        dialogue.name = "Ken";
        dialogue.sentences = startDialogue;

        started = true;
        FindObjectOfType<DialogueManagerRoom>().StartDialogueRoom(dialogue);
	}

    public void NextQuestion(int number)
    {
        Dialogue dialogue = new Dialogue();

        dialogue.name = "Ken";
        dialogue.sentences = (string[]) questionlist[number];
        string right = rightAnswer[number];
        string wrong = wrongAnswer[number];
        string hintBox = hint[number];

        started = true;
        FindObjectOfType<DialogueManagerRoom>().StartDialogueRoom(dialogue, right, wrong, hintBox);
    }


}
