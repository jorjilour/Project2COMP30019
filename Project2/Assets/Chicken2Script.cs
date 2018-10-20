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
		Vector3 chickenBounds = this.gameObject.GetComponent<Collider> ().bounds.size;
		Vector3 platfromSize = platform.GetComponent<Collider> ().bounds.size;

		float zSize = platfromSize.z;
		zSize /= 2; 

		float xSize = platfromSize.x;
		xSize /= 2; 

		//Randomly positions the chickens
		Vector3 pos = this.transform.position; 
		pos.y += chickenBounds.y / 8.0f;
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

		transform.eulerAngles -= new Vector3(0.0f, Random.Range(90.0f,270.0f), 0);

		InvokeRepeating("RotateChicken", 1f, 3.0f);
		pos = this.transform.position; 
		if (pos.x <= xUpperBound && pos.x >= xLowerBound && pos.z <= zUpperBound && pos.z >= zLowerBound) {
			print ("started within bounds");
			//move towards its forward
		} else {
			if (pos.x < xUpperBound || pos.x > xLowerBound) {
				print ("started outside x bounds");
				Vector3 newPos = this.transform.position;
				pos.x = Random.Range (xLowerBound,xUpperBound);
				this.transform.position = newPos; 
			}
			if (pos.z < zUpperBound || pos.z > zLowerBound) {
				print ("started outside z bounds");
			}

			//set random x value
			//set random y value
			//set random z value

		}

//		xUpperBound -= chickenSize.x/2; 
//		xLowerBound += chickenSize.x/2; 
//		zUpperBound -= chickenSize.z/2; 
//		zLowerBound += chickenSize.z/2; 
	}

	// Update is called once per frame
	void Update () {
//		//make chicken move towards the vector3 forwards
		Vector3 curPos = this.transform.position;
//
//		//if it is within boundaries, move it
		if (curPos.x <= xUpperBound && curPos.x >= xLowerBound && curPos.z <= zUpperBound && curPos.z >= zLowerBound) {
			print ("within bounds");
			//move towards its forward
			transform.position += this.gameObject.transform.forward.normalized * speed; 
		} 
//		//if it is outside boundaries, rotate it so that it can move next time
		else {
			if (curPos.x > xUpperBound)
				print ("outside x's upper bound"); 
			if (curPos.x < xLowerBound)
				print ("outside x's upper bound"); 
			if (curPos.z > zUpperBound)
				print ("outside z's upper bound"); 
			if (curPos.z < zLowerBound)
				print ("outside z's upper bound"); 
			//rotate the chicken so it can move
			print ("outside bounds");

			int angle = findMoveableAngle (curPos);
			if (angle != 0) {
				transform.eulerAngles += new Vector3 (0.0f, angle, 0);
				transform.position -= this.gameObject.transform.forward.normalized * 0.5f; 

			} else {
				print ("cannot move");
			}
		}

//		print (this.transform.eulerAngles);

	}

	int findMoveableAngle (Vector3 curPos){
		Vector3 curAngle = transform.eulerAngles;
//		print ("finding moveable angle");
		for (int i =90;i<=270; i++){
			int randomAngle = (int)Random.Range (105.0f, 255.0f);
			transform.eulerAngles += new Vector3(0.0f, randomAngle, 0.0f);
			Vector3 newPos = curPos;
			if (insideBounds (newPos -= this.gameObject.transform.forward.normalized * 0.5f)) {
				transform.eulerAngles = curAngle; 
				return randomAngle; 
			} else {
//				print ("cannot move at angle " + i);
				transform.eulerAngles = curAngle; 
			}
		}

		transform.eulerAngles = curAngle; 
		return 0; 
		
	}
	bool insideBounds(Vector3 curPos){
		if (curPos.x <= xUpperBound && curPos.x >= xLowerBound && curPos.z <= zUpperBound && curPos.z >= zLowerBound) {
			return true;
		} 
		return false; 
	}

	void RotateChicken(){
		//rotate the y axis of the chicken
		float yRotation = Random.Range(-maxRotation,maxRotation);
		transform.eulerAngles += new Vector3(0.0f, yRotation, 0);
	}




}
