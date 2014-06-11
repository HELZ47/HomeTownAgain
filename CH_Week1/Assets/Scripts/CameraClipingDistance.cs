using UnityEngine;
using System.Collections;

public class CameraClipingDistance : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float[] distances = new float[32];
		for (int i = 0; i < 32; i++) {
			distances[i] = 25;
		}
		distances[10] = 1000;
		//distances [11] = 5;
		camera.layerCullDistances = distances;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
