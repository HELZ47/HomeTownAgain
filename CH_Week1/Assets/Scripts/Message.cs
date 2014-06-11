using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour {

	PlayerManager player;
	public string message;
	public bool selected;
	public ParticleSystem particles;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (particles) {
			particles.enableEmission = !selected;
		}
	}
}
