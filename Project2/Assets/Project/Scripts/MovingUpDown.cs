using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUpDown : MonoBehaviour {

	public int dir = 1;
	public float yT = 10;
	public float speed = 5;
    private float yThresholdDist;
	private float originalY;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();

		originalY = this.transform.localPosition.y;
		yThresholdDist = this.transform.localPosition.y + yT;
	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate(){
        yAxisShuffleM();

	}


	private void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "MainCamera"){
			Debug.Log("Player on moving floor");
//collision.gameObject.transform.parent = this.transform;
		}
	} 

	private void OnCollisionExit(Collision collision){
		// if (collision.transform.tag == "Player"){
		// 	collision.transform.parent = null;
		// }
	}

	public void yAxisShuffleM()
    {

        rb.position += Vector3.up * Time.deltaTime * dir * speed;

        if (this.transform.localPosition.y > yThresholdDist)
        {
            dir = -1;

        }
        else if (this.transform.localPosition.y < originalY)
        {
            dir = 1;
        }

    }
}
