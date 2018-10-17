using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{

    //code copied from COMP30019 Lab 7 
    public int startingHealth = 100;
    private int currentHealth;
    private int damage = 10;
    private float timeLeft = 3.0f;
    private int powerUp = 10;
    private PlayerController controller;
    public Slider healthSlider;
    private bool damaged;

    // Use this for initialization
    void Start()
    {
        this.ResetHealthToStarting();
        controller = GetComponent<PlayerController>();
        timeLeft = -1.0f;
        damaged = true;

        healthSlider.direction = Slider.Direction.RightToLeft;
        healthSlider.value = 100;
    }

    private void Update()
    {
        if(damaged)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                damaged = false;
            }
        }
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
        healthSlider.value = currentHealth;
        print(healthSlider.value);
        print(currentHealth);

        if (currentHealth <= 0)
        {
            controller.decreaseLives();
            
            //			Destroy(this.gameObject);
        }
    }

    public void ApplyPowerUp()
    {
        currentHealth += powerUp;
        healthSlider.value = currentHealth;
    }

    // Get the current health of the object
    public int GetHealth()
    {
        return this.currentHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && timeLeft < 0)
        {
            //print ("hit an enemy, health --"); 
            print("current health is now " + currentHealth);
            ApplyDamage();
            damaged = true;
            timeLeft = 1.0f;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "PowerUp")
        {
            print ("collected a power up, health++");
            ApplyPowerUp();

            Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "Goal")
        {
            FinishedALevel.Instance.GoalReached();
        }
    }

}
