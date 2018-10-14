using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Add Random Trees and Enemies on platform **/

public class MakePlatform : MonoBehaviour {
    public GameObject platform;

    public GameObject[] naturePrefabs;
    public GameObject[] enemiesPrefabs;

    private int minNSpawn = 5;
    private int maxNSpawn = 10;
    private int maxNEnemies = 3;

    private int nEnemies;
    private int nSpawns;

    private string prefabFolder = "SummerPrefabs";





    // Use this for initialization
    void Start () {
        //Load all prefabs needed 
        naturePrefabs = Resources.LoadAll<GameObject>("SummerPrefabs");


        nSpawns = Random.Range(minNSpawn, maxNSpawn);
        nEnemies = Random.Range(1, maxNEnemies);

        for(int i=0; i<nSpawns; i++) SpawnNatureObject(naturePrefabs);

        for (int i = 0; i < nEnemies; i++) SpawnEnemy(enemiesPrefabs);

    }
    
    
    //adapted from: https://answers.unity.com/questions/711778/adding-prefabs-to-a-list-or-an-array-from-a-folder.html
    void SpawnNatureObject(GameObject[] objects)
    {

        //spawns item in array position between 0 and 100
        int whichItem = (int) Random.Range(0, objects.Length - 1);

        GameObject randObject = Instantiate(objects[whichItem]);
        //randObject.transform.position = Vector3.zero;
        randObject.transform.position = NextRandomPosition(randObject, platform);
    }

    void SpawnEnemy(GameObject[] objects)
    {

        //spawns item in array position between 0 and 100
        int whichItem = (int)Random.Range(0, objects.Length - 1);
        print("enemyobjects.length: " + objects.Length) ;
        print("whichEnemyItem: " + whichItem);
        GameObject randObject = Instantiate(objects[whichItem]);

        //assign this platform to chickenScript or dragonScript
        if(randObject.tag == "Enemy")
        {
            var chickenController = randObject.GetComponent<ChickenScript>();
            chickenController.AssignPlatform(this.gameObject);
        } else
        {
            var dragonScript = randObject.GetComponent<DragonScript>();
            dragonScript.AssignPlatform(this.gameObject);
        }

        randObject.transform.position = Vector3.zero;
        randObject.transform.position = NextRandomEnemyPosition(randObject, platform);

    }

    Vector3 NextRandomPosition(GameObject spawn, GameObject platform)
    {
        var center = this.transform.position;

        var spawnSize = spawn.GetComponent<MeshRenderer>().bounds.size;
        var platformSize = platform.GetComponent<MeshRenderer>().bounds.size;

        //Debug.Log("spawnsize : " + spawnSize);
        //Debug.Log("platform size : " + platformSize);
        float dY = platformSize.y/2;

        float minX = -(platformSize.x / 2 - spawnSize.x);
        float maxX = -minX;

        float minZ = -(platformSize.z / 2 - spawnSize.z);
        float maxZ = -minZ;


        Vector3 newRandPos = center + new Vector3(Random.Range(minX, maxX),
                                dY,
                                Random.Range(minZ, maxZ));

        print("treePos at" + center + ": " + newRandPos);
        return newRandPos;
    }

    Vector3 NextRandomEnemyPosition(GameObject spawn, GameObject platform)
    {
        var center = this.transform.position;

        var spawnSize = spawn.GetComponent<MeshRenderer>().bounds.size;
        var platformSize = platform.GetComponent<MeshRenderer>().bounds.size;

        Debug.Log("spawnsize : " + spawnSize);
        Debug.Log("platform size : " + platformSize);
        float dY = platformSize.y / 2;

        float minX = -(platformSize.x / 2 - spawnSize.x/2) ;
        float maxX = -minX;

        float minZ = -(platformSize.z / 2 - spawnSize.z/2);
        float maxZ = -minZ;

        if (spawn.tag == "Enemy2")
        {
            float minY = 4.0f;
            float maxY = 6.0f;
            dY = Random.Range(minY, maxY);
        }


        Vector3 newRandPos = center + new Vector3(Random.Range(minX, maxX),
                                dY,
                                Random.Range(minZ, maxZ));

        print("treePos at" + center + ": " + newRandPos);
        return newRandPos;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
