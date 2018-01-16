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

    // Use this for initialization
    void Start()
    {
        soundEffect = FindObjectOfType<SoundEffectManager>();
        goomba = GetComponent<Rigidbody2D>();
        goombaAnimation = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        this.goomba.velocity = new Vector2(speed * speed, this.goomba.velocity.y);

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
                else if (hitPos.normal.y < 0 || hitPos.normal.x < 0 || hitPos.normal.x > 0)
                {
                    MarioControllerScript.hasDied = true;
                }

            }
        }
    }
}
