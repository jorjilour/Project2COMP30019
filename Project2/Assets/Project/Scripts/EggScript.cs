using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour {
    public ParticleSystem particleSystemPrefab; 
	public GameObject dragon; 

	// Use this for initialization
	void Start () {
		dragon = this.transform.parent.gameObject;
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject != dragon ) {
			Explode (); 
		}


	}
		
	// Update is called once per frame
	void Explode () {
        ParticleSystem particleSystemInstance = Instantiate<ParticleSystem>(particleSystemPrefab);
//		particleSystemInstance.transform.parent = this.gameObject.transform.parent;
        particleSystemInstance.transform.position = this.gameObject.transform.position;

        Destroy(this.gameObject);
	}

}
