using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour {
	private GameObject platform; 
	private float thresholdMax ; 
	private float thresholdMin ; 
	public GameObject egg; 

	private int dir;
	private float speed;

	// Use this for initialization
	void Start () {
		platform = this.transform.parent.gameObject;
		Vector3 platformSize = platform.GetComponent<Collider> ().bounds.size; 
		float xSize = platformSize.x;
		float zSize = platformSize.z;

		//Randomly locates the dragon
		Vector3 position = platform.transform.position; 
		position.x += Random.Range(-xSize/2,xSize/2); 
		position.y += Random.Range (7.0f,12.0f);
		this.transform.position = position; 

		//set threshold distance or position
		float thresholdDistance = zSize;
		thresholdDistance = thresholdDistance/2; 
		thresholdMax = platform.transform.position.z + thresholdDistance - 2.0f; 
		thresholdMin = platform.transform.position.z - thresholdDistance + 2.0f; 

		dir = 1;
		speed = Random.Range (0.01f,0.3f);

		InvokeRepeating("LayEggs", 3.0f, 4.5f);


	}

	// Update is called once per frame
	void Update () {
		//move the dragon
		this.transform.localPosition += Time.deltaTime * Vector3.forward * speed * dir;

		//change the direction it is moving to
		//make object look towards the direction it is moving
		if (this.transform.position.z > thresholdMax){
			this.transform.rotation = new Quaternion (0,1,0,0);
			dir = -1;
		} else if (this.transform.position.z < thresholdMin){
			this.transform.rotation = new Quaternion (0,0,0,1);
			dir = 1;
		}
	}


	void LayEggs()
	{
		GameObject newEgg = Instantiate<GameObject>(egg);
		newEgg.transform.parent = this.gameObject.transform;

		Vector3 position = this.gameObject.transform.position;
		newEgg.transform.position = position;
	}


}
