using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Animator animator;
    private Control movement;
    private GameObject player;
    public GameObject smoke;
    private bool isJumping = false;
    private bool isLayDown = false;

    private bool movable = true;
    private bool talkable = true;

    private bool started = false;
    private bool alerted = false;
    private bool smokeAlertedOne = false;
    private bool smokeAlertedTwo = false;

    private float speed;
    private float x;
    private float y;
    public float moveSpeed = 10.0f;


    private string[] leftLimitAlertClass = { "Bên đó đang cháy đấy. Tớ sợ lắm. Hãy quay lại đi" };
    private string[] rightLimitAlertClass = { "Không có gì phía trước đâu. Quay lại đi" };
    private string[] startClassDialogue = { "Tan học rồi! Đi về thôi." };
    private string[] fireAtDoorAlert = { "Cửa lớp đang cháy kìa. Chúng ta phải thoát ra bằng cửa còn lại thôi!" };
    private string[] smokeAlertEncounter = { "Phía trước nhiều khói quá. Chúng phải nghĩ cách để vượt qua thôi." };
    private string[] smokeAlertTouch = { "Khó thở quá. Không chạy qua được đâu. Có lẽ chúng ta nên bò qua thôi" };
    

    void Awake()
    {
        //References
        movement = GetComponent<Control>();
        player = GameObject.Find("Main");
    }

    private void Start()
    {
        x = Input.GetAxis("Horizontal");
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {

        //Left Limit Alert Dialogue
        if(player.transform.position.x <= 1)
        {
            movable = false;
            talkable = true;
            speed = 0.0f;
            moveSpeed = 0.0f;
            animator.SetFloat("BlendTreeSpeed", 0.0f);
            movement.SetSpeed(0.0f);

            if (isLayDown)
            {
                movement.LowMove(speed, isLayDown, moveSpeed);
            }
            if (!isLayDown)
            {
                movement.HighMove(speed, isJumping, moveSpeed);
            }

            Dialogue dialogue = new Dialogue();
            dialogue.sentences = leftLimitAlertClass;
            dialogue.name = "Ken";

            if (talkable)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }

            Vector3 savePosition = new Vector3(this.transform.position.x + 2.0f, this.transform.position.y, 10.0f);
            this.transform.position = savePosition;
        }
        else
        {
            movable = true;
            talkable = true;
        }

        //Right Limit Alert Dialogue
        if (player.transform.position.x >= 45)
        {
            movable = false;
            talkable = true;
            speed = 0.0f;
            moveSpeed = 0.0f;
            animator.SetFloat("BlendTreeSpeed", 0.0f);
            movement.SetSpeed(0.0f);

            if (isLayDown)
            {
                movement.LowMove(speed, isLayDown, moveSpeed);
            }
            if (!isLayDown)
            {
                movement.HighMove(speed, isJumping, moveSpeed);
            }

            Dialogue dialogue = new Dialogue();
            dialogue.sentences = rightLimitAlertClass;
            dialogue.name = "Ken";

            if (talkable)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }

            Vector3 savePosition = new Vector3(this.transform.position.x - 2.0f, this.transform.position.y, 10.0f);
            this.transform.position = savePosition;
        }
        else
        {
            movable = true;
            talkable = true;
        }

        //Start Scene Dialogue
        if (player.transform.position.x <= 14 && !started)
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
            movable = false;
            talkable = true;
            speed = 0.0f;
            moveSpeed = 0.0f;
            animator.SetFloat("BlendTreeSpeed", 0.0f);
            movement.SetSpeed(0.0f);

            if (isLayDown)
            {
                movement.LowMove(speed, isLayDown, moveSpeed);
            }
            if (!isLayDown)
            {
                movement.HighMove(speed, isJumping, moveSpeed);
            }

            Dialogue dialogue = new Dialogue();
            dialogue.sentences = startClassDialogue;
            dialogue.name = "Ken";

            if (talkable)
            {
                started = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
        else
        {
            movable = true;
            talkable = true;
        }

        //First Encounter With Fire
        if (player.transform.position.x <= 3.5 && !alerted)
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
            movable = false;
            talkable = true;
            speed = 0.0f;
            moveSpeed = 0.0f;
            animator.SetFloat("BlendTreeSpeed", 0.0f);
            movement.SetSpeed(0.0f);

            if (isLayDown)
            {
                movement.LowMove(speed, isLayDown, moveSpeed);
            }
            if (!isLayDown)
            {
                movement.HighMove(speed, isJumping, moveSpeed);
            }

            Dialogue dialogue = new Dialogue();
            dialogue.sentences = fireAtDoorAlert;
            dialogue.name = "Ken";

            if (talkable)
            {
                alerted = true;
                smoke.SetActive(true);
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
        else
        {
            movable = true;
            talkable = true;
        }

        //First Encounter With Smoke
        if (player.transform.position.x >= 14.5f && !smokeAlertedOne)
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
            movable = false;
            talkable = true;
            speed = 0.0f;
            moveSpeed = 0.0f;
            animator.SetFloat("BlendTreeSpeed", 0.0f);
            movement.SetSpeed(0.0f);

            if (isLayDown)
            {
                movement.LowMove(speed, isLayDown, moveSpeed);
            }
            if (!isLayDown)
            {
                movement.HighMove(speed, isJumping, moveSpeed);
            }

            Dialogue dialogue = new Dialogue();
            dialogue.sentences = smokeAlertEncounter;
            dialogue.name = "Ken";

            if (talkable)
            {
                smokeAlertedOne = true;
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
        else
        {
            movable = true;
            talkable = true;
        }

        //While in smoke
        if (player.transform.position.x >= 21.5f && isLayDown == false)
        {
            FindObjectOfType<DialogueManager>().EndDialogue();
            movable = false;
            talkable = true;
            speed = 0.0f;
            moveSpeed = 0.0f;
            animator.SetFloat("BlendTreeSpeed", 0.0f);
            movement.SetSpeed(0.0f);

            if (isLayDown)
            {
                movement.LowMove(speed, isLayDown, moveSpeed);
            }
            if (!isLayDown)
            {
                movement.HighMove(speed, isJumping, moveSpeed);
            }

            Dialogue dialogue = new Dialogue();
            dialogue.sentences = smokeAlertTouch;
            dialogue.name = "Ken";

            if (talkable)
            {
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }

            Vector3 savePosition = new Vector3(this.transform.position.x - 3.0f, this.transform.position.y, 10.0f);
            this.transform.position = savePosition;
        }
        else
        {
            movable = true;
            talkable = true;
        }

        //Movement Control
        if (movable)
        {
            moveSpeed = 10.0f;
            if (Input.GetKey(KeyCode.A))
            {
                if (isLayDown)
                {
                    speed = -0.3f;
                }
                if (!isLayDown)
                {
                    speed = -0.5f;
                }

            }
            else if (Input.GetKey(KeyCode.D))
            {
                if (isLayDown)
                {
                    speed = 0.3f;
                }
                if (!isLayDown)
                {
                    speed = 0.5f;
                }
            }
            else
            {
                speed = 0;
            }
            if (movement.isIdle)
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    movement.LayDown(true);
                    isLayDown = true;
                }
            }
            if (movement.isLayDown)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    movement.StandUp(true);
                    isLayDown = false;
                }
            }
            if (isLayDown)
            {
                movement.LowMove(speed, isLayDown, moveSpeed);
            }
            if (!isLayDown)
            {
                movement.HighMove(speed, isJumping, moveSpeed);
            }
        }
    }
}
