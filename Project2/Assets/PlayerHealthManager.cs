using UnityEngine;
using System.Collections;

public class PlayerHealthManager : MonoBehaviour
{

    //code copied from COMP30019 Lab 7 
    public int startingHealth = 100;
	public ParticleSystem firework; 
	public ParticleSystem fireworkChild; 

    private int currentHealth;
    private int damage = 30;
    private int powerUp = 10;
    private PlayerController controller;

    // Use this for initialization
    void Start()
    {
        this.ResetHealthToStarting();
        controller = GetComponent<PlayerController>();
    }

    // Reset health to original starting health
    public void ResetHealthToStarting()
    {
        currentHealth = startingHealth;
    }

    // Reduce the health of the object by a certain amount
    // If health lte zero, destroy the object
    public void ApplyDamage()
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            controller.decreaseLives();
            //			Destroy(this.gameObject);
        }
    }

    public void ApplyPowerUp()
    {
        currentHealth += powerUp;
    }

    // Get the current health of the object
    public int GetHealth()
    {
        return this.currentHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
		print ("player collided with something "+collision.gameObject);
        if (collision.gameObject.tag == "Enemy")
        {
            //print ("hit an enemy, health --"); 
            print("current health is now " + currentHealth);
            ApplyDamage();
        }

		if (collision.gameObject.tag=="Goal"){
			print ("touched goal!");
		}

		if (collision.gameObject.tag=="Explosion"){
			print ("hit an explosion");
		}
    }

    void OnTriggerEnter(Collider other)
    {
		print ("triggered goal ");
		if (other.gameObject.tag == "Goal"){
			Destroy (other.gameObject);

			ParticleSystem fireworkInstance = Instantiate<ParticleSystem>(firework);
			fireworkInstance.transform.position = this.gameObject.transform.position;

			Destroy(GetComponent<SmoothMouseLook>());

			this.transform.eulerAngles -= new Vector3(90.0f, 0.0f, 0.0f);
//			this.transform.rotation = new Quaternion (0.0, 0.3, 0.0, 1.0);
//			print ("rotation is now "+this.transform.rotation);

		}
        if (other.gameObject.tag == "PowerUp")
        {
            print ("collected a power up, health++");
            ApplyPowerUp();

            Destroy(other.gameObject);
        }
    }



}
