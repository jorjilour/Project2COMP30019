using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Add Random Trees and Enemies on platform **/

public class MakePlatform : MonoBehaviour {

	public GameObject[] naturePrefabs;
	public GameObject[] enemiesPrefabs;

	public int minNSpawn = 5;
	public int maxNSpawn = 15;
	public int maxNEnemies = 2;
	public int minNEnemies = 2; 

	private int nEnemies;
	private int nSpawns;

	// Use this for initialization
	void Start () {
		//Load all prefabs needed 
		naturePrefabs = Resources.LoadAll<GameObject>("SummerPrefabs");
		enemiesPrefabs = Resources.LoadAll<GameObject>("EnemyPrefabs");
		//		print (enemiesPrefabs.Length);


		nSpawns = Random.Range(minNSpawn, maxNSpawn);
		nEnemies = Random.Range(minNEnemies, maxNEnemies);

		for(int i=0; i<nSpawns; i++) SpawnNatureObject(naturePrefabs);

				for (int i = 0; i < nEnemies; i++) SpawnEnemy(enemiesPrefabs);

	}


	//adapted from: https://answers.unity.com/questions/711778/adding-prefabs-to-a-list-or-an-array-from-a-folder.html
	void SpawnNatureObject(GameObject[] objects)
	{
		//spawns item in array position between 0 and 100
		int whichItem = (int) Random.Range(0, objects.Length - 1);

		GameObject randObject = Instantiate(objects[whichItem]);
		randObject.transform.parent = this.gameObject.transform;

		//randObject.transform.position = Vector3.zero;
		randObject.transform.position = NextRandomPosition(randObject, this.gameObject);
	}

	void SpawnEnemy(GameObject[] objects)
	{
		//spawns item in array position between 0 and 100
		float whichItem = Random.Range(0, objects.Length - 1 + 0.5f);


		//		print("enemyobjects.length: " + objects.Length) ;
		//		print("whichEnemyItem: " + whichItem);

		GameObject randObject = Instantiate(objects[(int)whichItem]);
		randObject.transform.parent = this.gameObject.transform;

		//		//assign this platform to chickenScript or dragonScript
		if(randObject.tag == "Chicken")
		{
			var chickenController = randObject.GetComponent<ChickenScript>();
			//			chickenController.AssignPlatform(this.gameObject);
		} else if(randObject.tag == "Dragon"){
			var dragonScript = randObject.GetComponent<DragonScript>();
			//			dragonScript.AssignPlatform(this.gameObject);
		}

		randObject.transform.position = NextRandomEnemyPosition(randObject, this.gameObject);

	}

	Vector3 NextRandomPosition(GameObject spawn, GameObject platform)
	{
		var center = this.transform.position;

		var spawnSize = spawn.GetComponent<MeshRenderer>().bounds.size;
		var platformSize = platform.GetComponent<MeshRenderer>().bounds.size;

//		print ("centered at y position of "+center.y);
		//Debug.Log("spawnsize : " + spawnSize);
		//Debug.Log("platform size : " + platformSize);
		float dY = platformSize.y/2;


//		print ("half the platform dY is "+dY);

		float minX = -(platformSize.x / 2 - spawnSize.x);
		float maxX = -minX;

		float minZ = -(platformSize.z / 2 - spawnSize.z);
		float maxZ = -minZ;


		Vector3 newRandPos = center + new Vector3(Random.Range(minX, maxX),
			dY,
			Random.Range(minZ, maxZ));
//		print ("the new dY is"+newRandPos.y); 
		//		print("treePos at" + center + ": " + newRandPos);
		return newRandPos;
	}

	Vector3 NextRandomEnemyPosition(GameObject spawn, GameObject platform)
	{
		var center = this.transform.position;
//		print ("dy position of the platform is "+center.y);

		var spawnSize = spawn.GetComponent<MeshRenderer>().bounds.size;
//		print (spawnSize == null);
		var platformSize = platform.GetComponent<MeshRenderer>().bounds.size;


		Collider c = GetComponent<Collider> (); 
		float cY = c.bounds.size.y;

//		print ("cY is "+cY);

//		float dY = center.y;
		float dY = platformSize.y/2 + cY/8;
//		print (spawnSize.y);
		dY += spawnSize.y * 20.0f;

//		print ("half the platform dY is "+dY);

		float minX = -(platformSize.x / 2 - spawnSize.x);
		float maxX = -minX;

		float minZ = -(platformSize.z / 2 - spawnSize.z);
		float maxZ = -minZ;


		Vector3 newRandPos = center + new Vector3(0.0f,
			dY,
			0.0f);
//
//		Vector3 pos = this.gameObject.transform.position; 
//		float dY = 0.0f;
//
////		float dY = platformSize.y/2;
//
//		pos += new Vector3 (0.0f,dY,0.0f); 

		return newRandPos; 

	}

	// Update is called once per frame
	void Update () {

	}
}
