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


	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player"||other.gameObject.tag == "MainCamera")
		{
			FinishedALevel.Instance.GoalReached(level);   
		}
	}
}
