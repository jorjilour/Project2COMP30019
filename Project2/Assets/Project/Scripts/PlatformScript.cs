using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour {


    private float thresholdDistance=3;
    private float speed = 2.5f;

    private int dir = 1; // Switches when cube reverses direction

    // Update is called once per frame
    void Update()
    {
        this.transform.localPosition += Vector3.up * Time.deltaTime * speed * dir;
        if (this.transform.localPosition.y > 25.0f)
            dir = -1;
        else if (this.transform.localPosition.y < 17.0f)
            dir = 1;
    }
}
