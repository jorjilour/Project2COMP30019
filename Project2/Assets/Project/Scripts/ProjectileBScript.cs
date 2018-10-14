using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBScript : MonoBehaviour {

    private Camera cam;
    private Rigidbody m_RigidBody;
    public ParticleSystem particleSystemPrefab; 
    public Vector3 velocity;

    // Use this for initialization
    void Start()
    {
        m_RigidBody = GetComponent<Rigidbody>();
        cam = Camera.main;
        //velocity = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        print(velocity);
        if (!velocity.Equals(Vector3.zero))
        {
            this.transform.Translate(velocity * Time.deltaTime);
        }
        else
        {
            Vector3 desiredMove = cam.transform.forward;
            this.transform.position += desiredMove;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
		Debug.Log ("projectile has hit somethign");
        if (collision.gameObject.tag == "Enemy")
        {

            ParticleSystem particleSystemInstance = Instantiate<ParticleSystem>(particleSystemPrefab);
            particleSystemInstance.transform.position = this.gameObject.transform.position;

            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }
}
