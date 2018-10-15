using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour {
	private GameObject platform; 
	private float thresholdMax ; 
	private float thresholdMin ; 

	private int dir;
	private float speed;

	// Use this for initialization
	void Start () {
		platform = this.transform.parent.gameObject;
		float xSize = platform.GetComponent<Collider>().bounds.size.x;
		float zSize = platform.GetComponent<Collider>().bounds.size.z;

		Vector3 position = platform.transform.position; 
		position.x += Random.Range(-xSize/2,xSize/2); 
		position.y += Random.Range (7.0f,12.0f);

		this.transform.position = position; 
		float thresholdDistance = zSize;
		thresholdDistance = thresholdDistance/2; 

		thresholdMax = platform.transform.position.z + thresholdDistance - 2.0f; 
		thresholdMin = platform.transform.position.z - thresholdDistance + 2.0f; 

		//		print ("threshold max is"+thresholdMax);
		//		print ("threshold min is"+thresholdMin);


		dir = 1;
		speed = Random.Range (0.2f,0.8f);

	}

	// Update is called once per frame
	void Update () {
		this.transform.localPosition += Time.deltaTime * Vector3.forward * speed * dir;
		if (this.transform.position.z > thresholdMax){
			this.transform.rotation = new Quaternion (0,1,0,0);
			dir = -1;
		} else if (this.transform.position.z < thresholdMin){
			this.transform.rotation = new Quaternion (0,0,0,1);
			dir = 1;
		}
	}

	public void AssignPlatform(GameObject newPlatform){
		this.platform = newPlatform; 
	}

}
