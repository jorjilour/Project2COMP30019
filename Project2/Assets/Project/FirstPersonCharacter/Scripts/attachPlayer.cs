using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attachPlayer : MonoBehaviour {
	public GameObject Player; 
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {		
	}

	//code copied from https://www.youtube.com/watch?v=rO19dA2jksk&t=268s
	private void OnTriggerEnter(Collider other){
		Debug.Log ("trigger");
		if (other.gameObject == Player) {
			Debug.Log ("player trigger");
			Debug.Log (Player.transform.position);
			Debug.Log (this.transform.position);
			Player.transform.parent = this.transform;
		}
	}

	private void OnTriggerExit(Collider other){
		if (other.gameObject == Player) {
			Player.transform.parent = null; 
		}
	}
}
