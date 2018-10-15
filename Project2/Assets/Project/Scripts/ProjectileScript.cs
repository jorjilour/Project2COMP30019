using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

    private Camera cam;
    private Rigidbody m_RigidBody;
    public ParticleSystem particleSystemPrefab;
    public Vector3 velocity;


	// Use this for initialization
	void Start () {
        m_RigidBody = GetComponent<Rigidbody>();
        cam = Camera.main;
        //velocity = Vector3.zero;
		Vector3 desiredMove = cam.transform.forward;
		m_RigidBody.velocity = desiredMove * 15;

	}
	
	// Update is called once per frame
	void Update () {
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="Enemy" ||
            collision.gameObject.tag == "Enemy2")
        {
            
            ParticleSystem particleSystemInstance = Instantiate<ParticleSystem>(particleSystemPrefab);
            particleSystemInstance.transform.position = this.gameObject.transform.position;

            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }

        if (collision.gameObject.tag == "Enemy2")
        {
            print("HIT EL DRAGON!");
            ParticleSystem particleSystemInstance = Instantiate<ParticleSystem>(particleSystemPrefab);
            particleSystemInstance.transform.position = this.gameObject.transform.position;

            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }

		if (collision.gameObject.tag != "Gun") {
			Destroy (this.gameObject);
		}
    


	}
}
