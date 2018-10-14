using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalManager : MonoBehaviour {
    private static int level;
    // Use this for initialization
    void Start () {
        level = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("goal finished");
            FinishedALevel.Instance.GoalReached(level);   
        }
    }
}
