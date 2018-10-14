using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log("collided with something");

        if (other.tag=="Player"){
            Debug.Log("collided with particle system");
            Destroy(this);
        }
    }

    //code copied from https://www.youtube.com/watch?v=JTGv_maOyHk
	void onCollisionEnter(Collision col){
		Debug.Log ("touched something");
	}
}
