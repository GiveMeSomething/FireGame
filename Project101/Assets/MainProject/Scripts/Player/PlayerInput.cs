using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Animator animator;
    private Control movement;
    private GameObject player;
    private bool isJumping = false;
    private bool isLayDown = false;
    private bool movable = true;
    private bool talkable = true;
    private float speed;
    private float x;
    private float y;
    public float moveSpeed = 10.0f;


    private string[] leftLimitAlertClass = { "Bên đó đang cháy đấy. Tớ sợ lắm. Hãy quay lại đi" };
    private string[] rightLimitAlertClass = { "Không có gì phía trước đâu. Quay lại đi" };

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
