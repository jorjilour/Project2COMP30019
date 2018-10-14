using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggScript : MonoBehaviour {
    public ParticleSystem particleSystemPrefab; 

	// Use this for initialization
	void Start () {
        Invoke("Explode", 5.0f);
	}
	
	// Update is called once per frame
	void Explode () {
        ParticleSystem particleSystemInstance = Instantiate<ParticleSystem>(particleSystemPrefab);
        particleSystemInstance.transform.position = this.gameObject.transform.position;

        Destroy(this.gameObject);
	}
}
