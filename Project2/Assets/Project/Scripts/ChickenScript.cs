using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour {
	//platform for chicken to move around
	private GameObject platform; 
	public GameObject egg; 
	private float ySize ; 


	// Use this for initialization
	void Start () {
		platform = this.transform.parent.gameObject;

		float zSize = platform.GetComponent<Collider>().bounds.size.z;
		zSize /= 2; 

		ySize = platform.GetComponent<Collider>().bounds.size.y;

		Vector3 pos = this.transform.position; 
		pos.z += Random.Range (1.0f,zSize);
		pos.y += ySize;

		this.transform.position = pos; 

		LayEggs();
		InvokeRepeating("LayEggs", 3.0f, 4.5f);


	}

	// Update is called once per frame
	void Update () {
		transform.RotateAround(platform.transform.position,Vector3.down,0.5f);
		//Vector3.up; Vector3.forward;Vector3.right;
	}

	void LayEggs()
	{
		GameObject newEgg = Instantiate<GameObject>(egg);

		Vector3 position = this.gameObject.transform.position;
		position.y += ySize; 
		newEgg.transform.position = position;
	}

	public void AssignPlatform(GameObject newPlatform){
		this.platform = newPlatform; 
	}



}
