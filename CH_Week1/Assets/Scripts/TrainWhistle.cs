using UnityEngine;
using System.Collections;

public class TrainWhistle : MonoBehaviour {

	public float whistleInterval;
	public float lastWhistleTime;
	public bool whistling;

	public AudioSource source;

	// Use this for initialization
	void Start () {
		whistleInterval = 30f;
		whistling = true;
		lastWhistleTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (whistling && (Time.time - whistleInterval > lastWhistleTime)) { 
			audio.Play ();
			lastWhistleTime = Time.time;
		}
	}
}
