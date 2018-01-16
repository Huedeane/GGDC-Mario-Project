using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    SoundEffectManager soundEffect;

    public AudioClip coinSoundEffect;
    int CoinValue = 100;

    void Start()
    {
        soundEffect = FindObjectOfType<SoundEffectManager>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Mario")
        {
            soundEffect.playSoundEffect(coinSoundEffect);
            CoinScore.score++;
            MarioScore.score += CoinValue;
            Destroy(this.gameObject);

        }
    }
}
