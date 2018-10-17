using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformAttachPlayer : MonoBehaviour {
	private GameObject player; 

	// Use this for initialization
	//adapter from https://www.youtube.com/watch?v=rO19dA2jksk&t=1s
	void Start () {
		player = Camera.main.gameObject; 

		print ("player is "+ player);
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject == player) {
			print ("player is on platform ");
			player.transform.parent = this.transform;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.gameObject == player) {
			print ("player just exited the platform");
			player.transform.parent = null; 
		}
	}
}
