using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    int CoinValue = 100;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Mario") { 
        CoinScore.score++;
        MarioScore.score += CoinValue;
        Destroy(this.gameObject);
        }
    }
}
