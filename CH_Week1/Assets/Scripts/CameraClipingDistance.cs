using UnityEngine;
using System.Collections;

public class CameraClipingDistance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float[] distances = new float[32];

		//Clip everything at 25
		for (int i = 0; i < 32; i++) {
			distances[i] = 25;
		}

		//Clip message tree at default
		distances[10] = 0;

		//Clip walls
		distances [12] = 200;

		//Clip grass
		distances [11] = 15;
		camera.layerCullDistances = distances;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
