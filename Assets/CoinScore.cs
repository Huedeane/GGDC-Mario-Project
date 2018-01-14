using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinScore : MonoBehaviour {

    Text text;

    public static int score;

    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = string.Format("{0:00}", score);
    }
}
