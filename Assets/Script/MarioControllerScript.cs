using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MarioControllerScript : MonoBehaviour
{

    public float speed = 1.0f;
    public float jumpSpeed = 1.0f;
    public static bool hasDied;
    public LayerMask groundLayer;
    public AudioClip jumpSoundEffect;
    public AudioClip deathSoundEffect;

    private bool isGrounded;
    private Rigidbody2D mario;
    private Animator marioAnimation;
    private bool facingRight = true;
    private Transform groundCheck;
    private AudioSource audioPlayer;
    private bool playDeath;



    void Start()
    {
        mario = GetComponent<Rigidbody2D>();
        marioAnimation = GetComponent<Animator>();
        hasDied = false;
        isGrounded = false;
        playDeath = false;
        groundCheck = transform.Find("GroundCheck");
        audioPlayer = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, groundLayer);

        if (playDeath == false && ((gameObject.transform.position.y < -5.5 && hasDied == false) || hasDied == true))
        {
            hasDied = true;
            marioAnimation.SetBool("hasDied", true);
            playDeath = true;
            StartCoroutine(playDeathEvent());
        }

        //Movement on X-axis
        float marioSpeed = Input.GetAxis("Horizontal");
        marioAnimation.SetFloat("Speed", Mathf.Abs(marioSpeed));

        //Movement on Y-axis
        float marioJump = Input.GetAxis("Vertical");

        //Set true or false whether mario is on the ground
        marioAnimation.SetBool("isGrounded", isGrounded);


        /*If Movement on Y-axis yield greater then .001
         *and mario is grounded, then add force to the mario
         *and make him jump
         */
        if (marioJump > .001 && isGrounded)
        {
            if (jumpSoundEffect != null)
            {
                audioPlayer.clip = jumpSoundEffect;
                audioPlayer.Play();
            }
            mario.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);
            isGrounded = false;
        }

        //Set the velocity of mario
        this.mario.velocity = new Vector2(marioSpeed * speed, this.mario.velocity.y);

        //Flip mario
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


    public IEnumerator playDeathEvent()
    {
        
        //mario.constraints = RigidbodyConstraints2D.FreezeAll;

        Time.timeScale = 0;
        audioPlayer.clip = deathSoundEffect;
        audioPlayer.volume = 50;
        audioPlayer.Play();
        yield return new WaitWhile (() => audioPlayer.isPlaying);
        Time.timeScale = 1;
        Initiate.Fade("level 1", Color.black, 500f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    { 


    }
}
