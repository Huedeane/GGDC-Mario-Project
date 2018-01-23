using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

    SoundEffectManager soundEffect;

    public AudioClip brickSoundEffect;

    // Use this for initialization
    void Start () {
        soundEffect = FindObjectOfType<SoundEffectManager>();

    }
	
    void OnCollisionEnter2D(Collision2D collision)
    {
            foreach (ContactPoint2D hitPos in collision.contacts)
            {

                if (hitPos.normal.y > 0 && collision.gameObject.tag == "Player")
                {
                    soundEffect.playSoundEffect(brickSoundEffect);
                    Destroy(this.gameObject);
            }
            }
    }
}
