using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaContollerScript : MonoBehaviour
{
    SoundEffectManager soundEffect;
    private Rigidbody2D goomba;
    private Animator goombaAnimation;
    public AudioClip goombaDeathSoundEffect;
    
    public float speed = 1f;
    int monsterValue = 100;
    private Transform frontCheck;

    public LayerMask solidLayer;
    private bool isWalled;
    SpriteRenderer mySprite;
    public bool faceRight = true;


    // Use this for initialization
    void Start()
    {
        isWalled = false;
        soundEffect = FindObjectOfType<SoundEffectManager>();
        goomba = GetComponent<Rigidbody2D>();
        goombaAnimation = GetComponent<Animator>();
        frontCheck = transform.Find("frontCheck");
        mySprite = this.GetComponent<SpriteRenderer>();
        if (!faceRight)
            Flip();
    }

    void FixedUpdate()
    {
        if (mySprite.isVisible == true)
        {
            goomba.constraints = RigidbodyConstraints2D.None;
            goomba.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else if (mySprite.isVisible == false){
            goomba.constraints = RigidbodyConstraints2D.FreezeAll;
        }

        isWalled = Physics2D.OverlapPoint(frontCheck.position, solidLayer);

        if (isWalled)
        {
            Flip();
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x * speed, GetComponent<Rigidbody2D>().velocity.y);

        if (goombaAnimation.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            soundEffect.playSoundEffect(goombaDeathSoundEffect);
            MarioScore.score += monsterValue;
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (ContactPoint2D hitPos in collision.contacts)
            {
                if (hitPos.normal.y < 0)
                {
                    goombaAnimation.SetBool("hasDied", true);
                }
                else if (hitPos.normal.y > 0 || hitPos.normal.x < 0 || hitPos.normal.x > 0)
                {
                    MarioControllerScript.hasDied = true;
                }

            }
        }
        else if (collision.gameObject.tag == "Enemy")
        {
            Flip();
        }
    }

    public void Flip()
    {
        Vector3 enemyScale = transform.localScale;
        enemyScale.x *= -1;
        transform.localScale = enemyScale;
    }
}
