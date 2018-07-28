using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Animator anim;

    public LayerMask ground;
    public bool isGrounded;
    public Transform groundPrefab;

    public Rigidbody2D rbody;

    public float speed;

    public bool facingRight;
    public bool isIdle;
    public bool isLayDown;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        Flip();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundPrefab.position, 0.2f, ground);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                isGrounded = true;
        }
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("Speed", rbody.velocity.y);
        if (anim.GetFloat("BlendTreeSpeed") == 0)
        {
            isIdle = true;
        }
    }

    public void HighMove(float move, bool jump)
    {
        anim.SetFloat("BlendTreeSpeed", Mathf.Abs(move));

        rbody.velocity = new Vector2(move * speed, rbody.velocity.y);

        if (move > 0 && !facingRight)
        {

            Flip();
        }
        else if (move < 0 && facingRight)
        {

            Flip();
        }
        if (jump)
        {
            anim.SetBool("Jump", true);
            jump = false;
        }
    }

    public void LowMove(float move, bool isLayDown)
    {
        if (isLayDown)
        {
            anim.SetFloat("CrawlingSpeed", Mathf.Abs(move));
            rbody.velocity = new Vector2(move * speed, rbody.velocity.y);
            if (move > 0 && !facingRight)
            {
                Flip();
            }
            else if (move < 0 && facingRight)
            {
                Flip();
            }
        }
    }

    public void LayDown(bool possible)
    {
        if (possible)
        {
            anim.SetBool("standUp", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("isLayDown", true);
            anim.SetBool("Crawlable", true);
            isLayDown = true;
        }

    }

    public void StandUp(bool possible)
    {
        if (possible)
        {
            anim.SetBool("standUp", true);
            anim.SetBool("isLayDown", false);
            anim.SetBool("isIdle", false);
            possible = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x = scale.x * -1;
        transform.localScale = scale;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
