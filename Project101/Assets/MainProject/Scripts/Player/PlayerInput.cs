using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    private Control movement;
    private bool isJumping = false;
    private bool isLayDown = false;
    private float speed;
    private float x;
    private float y;
	void Awake()
    {
        //References
        movement = GetComponent<Control>();
	}
    private void Start()
    {
        x = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if(isLayDown)
            {
                speed = -0.3f;
            }
            if (!isLayDown)
            {
                speed = -0.5f;
            }
           
        }else if (Input.GetKey(KeyCode.D))
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
        if(movement.isIdle)
        {
            if(Input.GetKeyDown(KeyCode.S))
            {
                movement.LayDown(true);
                isLayDown = true;
            }
        }
        if(movement.isLayDown)
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                movement.StandUp(true);
                isLayDown = false;
            }       
        }
        if (isLayDown)
        {
            movement.LowMove(speed,isLayDown);
        }
        if(!isLayDown)
        {
            movement.HighMove(speed,isJumping);
        }
    }
}
