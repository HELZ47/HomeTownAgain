using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour {

//	GameObject player;
	public string message;
	public bool selected;
	public ParticleSystem particles;

	// Use this for initialization
	void Start () {
//		player = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		particles.enableEmission = !selected;
	}
}
