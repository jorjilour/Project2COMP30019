using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour {
	private GameObject platform; 
	private float thresholdMax ; 
	private float thresholdMin ; 

	private int dir;
	private float speed = 5.0f;

    public void AssignPlatform(GameObject newPlatform)
    {
        this.platform = newPlatform;
    }

    // Use this for initialization
    void Start () {
		Vector3 position = platform.transform.position; 
		position.y = 5.0f; 
		this.transform.position = position; 

		float thresholdDistance = platform.transform.localScale.z;
		thresholdDistance = thresholdDistance / 2; 

		thresholdMax = platform.transform.position.z + thresholdDistance; 
		thresholdMin = platform.transform.position.z - thresholdDistance; 

		dir = 1;

	}

	// Update is called once per frame
	void Update () {
		this.transform.localPosition += Time.deltaTime * Vector3.forward * speed*dir;
		if (this.transform.position.z > thresholdMax){
			this.transform.rotation = new Quaternion (0,1,0,0);
			dir = -1;
		} else if (this.transform.position.z < thresholdMin){
			this.transform.rotation = new Quaternion (0,0,0,1);
			dir = 1;
		}
	}
}
