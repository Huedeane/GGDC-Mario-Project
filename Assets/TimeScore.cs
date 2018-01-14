using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimeScore : MonoBehaviour {

    public int timeLeft = 200;
    //public GameObject mario;
    Text text;

    // Use this for initialization
    void Start()
    {
        //  mario = GameObject.Find("Mario");
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
            Debug.Log("Game over");

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
