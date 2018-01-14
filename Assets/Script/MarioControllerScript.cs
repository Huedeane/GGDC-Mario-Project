using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioControllerScript : MonoBehaviour
{

    public float speed = 1.0f;
    public float jumpSpeed = 1.0f;
    private Rigidbody2D mario;
    private Animator marioAnimation;
    private bool facingRight = true;
    private bool isGrounded;

    void Start()
    {
        mario = GetComponent<Rigidbody2D>();
        marioAnimation = GetComponent<Animator>();
        isGrounded = false;

    }

    void FixedUpdate()
    {
        float marioSpeed = Input.GetAxis("Horizontal");
        marioAnimation.SetFloat("Speed", Mathf.Abs(marioSpeed));

        marioAnimation.SetBool("isGrounded", isGrounded);

        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)
            {
                mario.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);
                isGrounded = false;
            }
        }

        this.mario.velocity = new Vector2(marioSpeed * speed, this.mario.velocity.y);

        if (marioSpeed > 0 && !facingRight)
        {
            Flip();
        }
        else if (marioSpeed < 0 && facingRight)
        {
            Flip();
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Solid")
        {
            isGrounded = true;
        }

        Collider2D collider = collision.collider;

        Vector3 contactPoint = collision.contacts[0].point;
        Vector3 center = collider.bounds.center;

        bool right = contactPoint.x > center.x;
        bool left = contactPoint.x < center.x;
        bool top = contactPoint.y > center.y;
        bool bot = contactPoint.y < center.y;


        if (right) {
            Debug.Log("Right");
        }
        if (left)
        {
            Debug.Log("left");
        }
        if (top)
        {
            Debug.Log("top");
        }
        if (bot)
        {
            Debug.Log("bot");
        }


    }
}
