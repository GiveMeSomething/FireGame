using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStartDialogue : MonoBehaviour {

    public bool started = false;
    public Button startButton;
    
    private string[] startDialogue = { "Về đến nhà rồi. Mình cùng ôn lại một bài học nhé." };
    
	void Start () {
		
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
}
