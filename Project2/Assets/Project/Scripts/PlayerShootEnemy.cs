using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootEnemy : MonoBehaviour {

    public float speed = 5.0f;
    public GameObject projectilePrefab;
    public GameObject projectilePrefab2;
    public float projectileSpeed = 30.0f;
	private GameObject projectileInitPos;

    // Use this for initialization
    void Start()
    {
		projectileInitPos = GameObject.FindWithTag ("ProjPos");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            //GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            //ParticleSystem particleSystem = Instantiate<ParticleSystem>(particleSystemPrefab);

            //projectile.transform.position = this.gameObject.transform.position;
            //particleSystem.transform.position = this.gameObject.transform.position;
            //particleSystem.transform.parent = projectile.transform;

            GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.position = projectileInitPos.transform.position;

			Destroy (projectile, 2.0f);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            //GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            //ParticleSystem particleSystem = Instantiate<ParticleSystem>(particleSystemPrefab);

            //projectile.transform.position = this.gameObject.transform.position;
            //particleSystem.transform.position = this.gameObject.transform.position;
            //particleSystem.transform.parent = projectile.transform;

            GameObject projectile = Instantiate<GameObject>(projectilePrefab2);
            projectile.transform.position = this.gameObject.transform.position;

        }

       

        if (Input.GetMouseButtonDown(1))
        {
            Vector2 mouseScreenPos = Input.mousePosition;

            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.transform.position.y;

            var worldPos = Camera.main.ScreenToWorldPoint(mousePosition);

            var direction = worldPos - transform.position;
            direction.Normalize();



            GameObject projectile = Instantiate<GameObject>(projectilePrefab2);
            projectile.transform.position = this.gameObject.transform.position;

            var projectileController = projectile.GetComponent<ProjectileScript>();
            projectileController.velocity = direction * projectileSpeed;
        }

    }
}
