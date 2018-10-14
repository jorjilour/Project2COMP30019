using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenScript : MonoBehaviour {
    //platform for chicken to move around
    private GameObject platform;
    //public GameObject platformPrefab;
    public GameObject egg; 


	// Use this for initialization
	void Start () {
        //LayEggs();
        InvokeRepeating("LayEggs", Random.Range(1.0f, 3.0f), Random.Range(5.0f, 10.0f));
        //platform = platformPrefab;

    }

    public void AssignPlatform(GameObject newPlatform)
    {
        this.platform = newPlatform;
    }
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(platform.transform.position-(Vector3.one*2),Vector3.up,0.5f);
	}

    void LayEggs()
    {
        GameObject newEgg = Instantiate<GameObject>(egg);

        var platformHeight = platform.GetComponent<MeshRenderer>().bounds.size.y;
        Vector3 chickPosition = this.gameObject.transform.position;

        float yPos = chickPosition.y + platformHeight / 2;

        chickPosition.y = yPos;
        newEgg.transform.position = chickPosition;
    }
}
