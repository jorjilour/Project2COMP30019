using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemLifespanScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(this.gameObject, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
