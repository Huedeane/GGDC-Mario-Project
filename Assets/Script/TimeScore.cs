using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class TimeScore : MonoBehaviour {

    public int defaultTimeLeft = 200;
    private int timeLeft;
    Text text;

    // Use this for initialization
    void Start()
    {
        if (defaultTimeLeft == 0)
        {
            defaultTimeLeft = 200;
        }
        timeLeft = defaultTimeLeft;
        text = GetComponent<Text>();
        StartCoroutine("LoseTime");
    }

    // Update is called once per frame
    void Update()
    {
        
        text.text = string.Format("{0:000}", timeLeft); ;

        if (timeLeft <= 0)
        {
            StopCoroutine("LoseTime");
            MarioControllerScript.hasDied = true;
        }

    }

    IEnumerator LoseTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeLeft--;
        }
    }
}
