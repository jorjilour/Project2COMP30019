using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed = 10.0f;
    public Rigidbody rigidBody;

    private float jumpSpeed = 5.0f;
    private bool jumping;
    private static int lives = 3;


    

    // Use this for initialization
    void Start () {
        Debug.Log("Started");
        jumping = false;
        //lives = 3;
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey(KeyCode.W))
        {
            Debug.Log("Press W");
            this.transform.localPosition += Camera.main.transform.forward * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            this.transform.localPosition += Camera.main.transform.forward* Time.deltaTime * speed * -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            this.transform.localPosition += Camera.main.transform.right * Time.deltaTime * speed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            this.transform.localPosition += Camera.main.transform.right * Time.deltaTime * speed * -1;
        }

        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
//			print ("player is jumping");
            Jump();
            jumping = true;
        }

        
    }

    void Jump()
    {
        Vector3 up = transform.TransformDirection(Vector3.up);
        rigidBody.AddForce(up * jumpSpeed, ForceMode.Impulse);
//		Vector3 pos = this.transform.localPosition;
//		pos.y += 5.0f; 
//		this.transform.localPosition = pos;

	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            this.jumping = false;
        }
        else if (collision.gameObject.tag == "Hell")
        {
           // Lost();
        }

    }

    private void Lost()
    {
        if(lives > 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            lives-=1;
            Debug.Log("Lives left: " + lives);
        } else
        {
          Debug.Log("Too bad");
        }
    }

    public void decreaseLives()
    {
        Debug.Log("DECREASE LI");
        //Lost();
    }

}
