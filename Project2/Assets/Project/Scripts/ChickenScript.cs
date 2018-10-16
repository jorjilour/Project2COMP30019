using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour {
	//platform for chicken to move around
	private Vector3 bounds; 
	private GameObject platform; 
//	public GameObject egg; 
	private float ySize ; 
	private float speed = 10.0f; 
	private float dir; 
	float leftMaxBound; 
	float downMaxBound;
	float rightMaxBound;
	float upMaxBound;
	float offsetBound;


	// Use this for initialization
	void Start () {
		platform = this.transform.parent.gameObject;
		Vector3 pos = this.transform.position;
		print ("pos is originally "+ pos);
		print ("bounds is "+bounds); 
//		print ("pos y is originally "+pos.y);

		float zSize = platform.GetComponent<Collider>().bounds.size.z;
		zSize /= 2; 

		bounds = platform.GetComponent<Collider>().bounds.size; 
		print ("bounds size is "+bounds);
		leftMaxBound = pos.z - bounds.z/2; 
		rightMaxBound = pos.z + bounds.z/2; 
		upMaxBound = pos.x + bounds.x/2; 
		downMaxBound = pos.x - bounds.x/2; 

		print ("leftMaxBound is" + leftMaxBound);
		print ("rightMaxBound is" + rightMaxBound);
		print ("upMaxBound is" + upMaxBound);
		print ("downMaxBound is" + downMaxBound);

		pos.z += Random.Range (1.0f,zSize);
//		pos.y += ySize;

		this.transform.position = pos;

//		LayEggs();
//		InvokeRepeating("LayEggs", 3.0f, 4.5f);

		dir = 1;
		speed = Random.Range (0.2f,0.8f);

//		print ("starting position of chicken is "+ pos.y);


	}

	// Update is called once per frame
	void Update () {
		this.transform.position = new Vector3 (1.0f,0.0f,0.0f); 
//		transform.RotateAround(platform.transform.position,Vector3.down,0.5f);
//		Vector3 movement= new Vector3(Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f),Random.Range(-1.0f,1.0f)); 

//		this.transform.localPosition += Time.deltaTime * movement * speed * dir;
//		if (this.transform.position > bounds){
//			this.transform.rotation = new Quaternion (0,1,0,0);
//			dir = -1;
//		} else if (this.transform.position < bounds){
//			this.transform.rotation = new Quaternion (0,0,0,1);
//			dir = 1;
//		}
//		Vector3.up; Vector3.forward;Vector3.right;


//		Vector3 currentPosition = this.transform.position;
//		currentPosition += new Vector3(Random.Range(-0.1f,0.1f),0.0f,Random.Range(-0.1f,0.1f));
//

		//annotated from
		// Check Left Map Bound
//		if (currentPosition.x < -(leftMaxBound))
//		{
//			currentPosition = Vector3.Lerp(
//				this.transform.position,
//				new Vector3(leftMaxBound, currentPosition.y, currentPosition.z),
//				speed * Time.deltaTime);
//		}
//		// Check Left Map Bound
//
//
//		// Check Down Map Bound
//		if (currentPosition.z < -(downMaxBound))
//		{
//			currentPosition = Vector3.Lerp(
//				this.transform.position,
//				new Vector3(this.transform.position.x, currentPosition.y, downMaxBound),
//				speed * Time.deltaTime);
//		}
//		// Check Down Map Bound
//
//
//		// Check Right Map Bound
//		if (currentPosition.x > rightMaxBound)
//		{
//			currentPosition = Vector3.Lerp(
//				currentPosition,
//				new Vector3(rightMaxBound, currentPosition.y, currentPosition.z),
//				speed * Time.deltaTime);
//		}
//		// Check Right Map Bound
//
//
//		// Check Up Map Bound
//		if (currentPosition.z > upMaxBound )
//		{
//			currentPosition = Vector3.Lerp(
//				currentPosition,
//				new Vector3(currentPosition.x, currentPosition.y, upMaxBound),
//				speed * Time.deltaTime);
//		}
//		// Check Up Map Bound
//
//		this.transform.position = currentPosition;
	}

//	void LayEggs()
//	{
//		GameObject newEgg = Instantiate<GameObject>(egg);
//
//		Vector3 position = this.gameObject.transform.position;
//		position.y += ySize; 
//		newEgg.transform.position = position;
//	}

	public void AssignPlatform(GameObject newPlatform){
		this.platform = newPlatform; 
	}



}
