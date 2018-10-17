using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken2Script : MonoBehaviour {
	//This chickenScript allows chicken to randomly move within borders of the platform
	private float speed = 0.05f; 
	private float maxRotation = 5.0f;

	private GameObject platform; 
	private GameObject player;

	private float xUpperBound; 
	private float xLowerBound;
	private float zUpperBound; 
	private float zLowerBound; 

	// Use this for initialization
	void Start () {
		player = Camera.main.gameObject ; 
		platform = this.transform.parent.gameObject;
		Vector3 platfromSize = platform.GetComponent<Collider> ().bounds.size;

		float zSize = platfromSize.z;
		zSize /= 2; 

		float xSize = platfromSize.x;
		xSize /= 2; 

		//Randomly positions the chickens
		Vector3 pos = this.transform.position; 
		pos.z += Random.Range (-zSize,zSize);
		pos.x += Random.Range (-xSize,xSize);
		this.transform.position = pos; 

		//set bounds
		Vector3 platformPosition = platform.transform.position; 
		Vector3 chickenSize = this.gameObject.GetComponent<Collider> ().bounds.size;
		xUpperBound = platformPosition.x + xSize - chickenSize.x/2; 
		xLowerBound = platformPosition.x - xSize + chickenSize.x/2; 
		zUpperBound = platformPosition.z + zSize - chickenSize.z/2; 
		zLowerBound = platformPosition.z - zSize + chickenSize.z/2; 

		transform.eulerAngles -= new Vector3(0.0f, Random.Range(0f,350.0f), 0);

		InvokeRepeating("RotateChicken", 1f, 3.0f);
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 center = platform.transform.position; 
//		Vector3 curPos = this.transform.position;
//		center.y = curPos.y; 


//		//Make chicken move towards player only if it is still within bounds
		//this code works but the chicken does not face the direction it is moving towards
//		if (curPos.x < xUpperBound && curPos.x > xLowerBound && curPos.z < zUpperBound && curPos.z > zLowerBound) {
//			float rate = Random.Range (0.0f, 0.01f);
//			Vector3 moveTowards = player.transform.position; 
//			moveTowards.y = curPos.y; 
//
//			this.transform.position = Vector3.Lerp (curPos, moveTowards, rate);
//
//
//		}

		//make chicken move towards the vector3 forwards
		Vector3 curPos = this.transform.position;
//		//if it is within boundaries, move it
		if (curPos.x < xUpperBound && curPos.x > xLowerBound && curPos.z < zUpperBound && curPos.z > zLowerBound) {
			//move towards its forward
			transform.position += this.gameObject.transform.forward.normalized * speed; 
		} 
		//if it is outside boundaries, rotate it so that it can move next time
		else {
			//rotate the chicken so it can move
			transform.eulerAngles -= new Vector3(0.0f, Random.Range(-95.0f,95.0f), 0);
			transform.position += this.gameObject.transform.forward.normalized * speed; 
		}

	}

	void RotateChicken(){
		//rotate the y axis of the chicken
		float yRotation = Random.Range(-maxRotation,maxRotation);
		transform.eulerAngles += new Vector3(0.0f, yRotation, 0);
	}


		

}
