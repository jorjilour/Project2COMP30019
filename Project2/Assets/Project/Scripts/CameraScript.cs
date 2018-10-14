using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    private float speed = 10f;
    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 height = Vector3.up * 0.5f;
        this.transform.localPosition = player.transform.localPosition;
    }
}
