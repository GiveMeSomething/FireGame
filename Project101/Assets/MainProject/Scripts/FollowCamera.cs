using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform player;

    public float smoothSpeed = 0.25f;

    private Vector2 offset;

    public bool movable = true;

    private string[] leftLimitAlertClass = { "Bên đó đang cháy đấy. Tớ sợ lắm. Hãy quay lại đi" };
    private string[] rightLimitAlertClass = { "Không có gì phía trước đâu. Quay lại đi" };

    // Use this for initialization
    void Start()
    {
        offset = new Vector2(5.0f, 0.0f);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (this.transform.position.x < 18 && this.transform.position.x > 0)
        {
            Vector2 playerPosition2D = new Vector2(player.position.x, this.transform.position.y);
            Vector2 position = playerPosition2D + offset;
            Vector2 smoothPosition = Vector2.Lerp(transform.position, position, smoothSpeed);

            transform.position = smoothPosition;
        }
        if(this.transform.position.x <= 0)
        {
            movable = false;

            Dialogue dialogue = new Dialogue();
            dialogue.sentences = leftLimitAlertClass;
            dialogue.name = "Ken";

            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
        if(this.transform.position.x >= 18)
        {
            movable = false;

            Dialogue dialogue = new Dialogue();
            dialogue.sentences = rightLimitAlertClass;
            dialogue.name = "Ken";

            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }
}
