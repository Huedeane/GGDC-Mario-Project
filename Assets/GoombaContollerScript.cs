using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaContollerScript : MonoBehaviour {

    public int EnemySpeed;
    public int XMoveDirection;

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D hitPos in collision.contacts) {
            Debug.Log(hitPos.normal);

        }
    }
}
