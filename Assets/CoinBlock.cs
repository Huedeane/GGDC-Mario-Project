using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    SoundEffectManager soundEffect;
    private Animator coinBlockAnimation;
    bool active;

    public AudioClip coinSoundEffect;
    int CoinValue = 100;

    void Start()
    {
        coinBlockAnimation = GetComponent<Animator>();
        active = true;
        soundEffect = FindObjectOfType<SoundEffectManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(active);
        if(active){
            foreach (ContactPoint2D hitPos in collision.contacts)
            {

                if (hitPos.normal.y > 0 && collision.gameObject.tag == "Player")
                {
                    coinBlockAnimation.SetTrigger("hitBlock");
                    active = false;
                    soundEffect.playSoundEffect(coinSoundEffect);
                    CoinScore.score++;
                    MarioScore.score += CoinValue;
                }
            }
        }
    }
}
