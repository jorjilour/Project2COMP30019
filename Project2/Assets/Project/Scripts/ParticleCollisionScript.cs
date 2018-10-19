using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollisionScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
       // Debug.Log(PlayerHealthManager.Instance.damaged);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        
        //PlayerHealthManager playerHealth = other.gameObject.GetComponent<PlayerHealthManager>();
        if (other.tag=="Player" || other.tag == "MainCamera"){
           // Debug.Log("collided with player");
            // PlayerHealthManager.Instance.ApplyDamage();
            // PlayerHealthManager.Instance.damaged = true;
            // PlayerHealthManager.Instance.timeLeft = 1.0f;
        }
       
    }

    
}
