using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScript : MonoBehaviour {
    public MeshFilter meshFilter;
	// Use this for initialization
	void Start () {

        Mesh mesh = meshFilter.mesh;

        Color[] colors = new Color[mesh.vertices.Length];

        for (int i = 0; i < mesh.vertices.Length; i++)
        {
            colors[i] = Color.blue;
        }
        meshFilter.mesh = mesh;
        meshFilter.mesh.colors = colors;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
