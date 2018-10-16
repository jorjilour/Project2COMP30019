using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken2Script : MonoBehaviour {
	//This chickenScript allows chicken to move towards players
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
		xUpperBound = platformPosition.x + xSize - chickenSize.x; 
		xLowerBound = platformPosition.x - xSize + chickenSize.x; 
		zUpperBound = platformPosition.z + zSize - chickenSize.z; 
		zLowerBound = platformPosition.z - zSize + chickenSize.z; 

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 center = platform.transform.position; 
		Vector3 curPos = this.transform.position;
		center.y = curPos.y; 


		//Make chicken move towards player only if it is still within bounds
		if (curPos.x<=xUpperBound && curPos.x>=xLowerBound && curPos.z<=zUpperBound && curPos.z>=zUpperBound){
			this.transform.position = Vector3.Lerp(curPos, player.transform.position,Random.Range(0.0f,0.1f));
		}
		transform.LookAt (player.transform);


		
	}
}
