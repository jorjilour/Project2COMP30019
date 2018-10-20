using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour {
	private GameObject platform; 
	private float thresholdMax ; 
	private float thresholdMin ; 
	public GameObject egg; 

	private int dir;
	private float speed;

	// Use this for initialization
	void Start () {
		Vector3 chickenBounds = this.gameObject.GetComponent<Collider> ().bounds.size;


		platform = this.transform.parent.gameObject;
		Vector3 platformSize = platform.GetComponent<Collider> ().bounds.size; 
		float xSize = platformSize.x;
		float zSize = platformSize.z;

		//Randomly locates the dragon
		Vector3 position = platform.transform.position;
		position.y += chickenBounds.y / 8.0f;
		position.x += Random.Range(-xSize/2,xSize/2); 
		this.transform.position = position; 

		//set threshold distance or position
		float thresholdDistance = xSize;
		thresholdDistance = thresholdDistance/2; 
		thresholdMax = platform.transform.position.x + thresholdDistance - 2.0f; 
		thresholdMin = platform.transform.position.x - thresholdDistance + 2.0f; 

		dir = 1;
		speed = Random.Range (0.01f,0.3f);

	}

	// Update is called once per frame
	void Update () {
		print(this.transform.rotation);
		//move the dragon
		this.transform.localPosition += Time.deltaTime * Vector3.right * speed * dir;

		//change the direction it is moving to
		//make object look towards the direction it is moving
		if (this.transform.position.x > thresholdMax){
			this.transform.rotation = new Quaternion (0,-1,0,1);
			dir = -1;
		} else if (this.transform.position.x < thresholdMin){
			this.transform.rotation = new Quaternion (0,1,0,1);
			dir = 1;
		}
	}




}
