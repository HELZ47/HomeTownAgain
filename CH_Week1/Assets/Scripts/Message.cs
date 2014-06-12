using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour {

	PlayerManager player;
	public string message;
	public bool selected;
	public ParticleSystem particles;
	public enum MessageType { Forrest, SmallCity, BigCity };
	public MessageType messageType;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Player").GetComponent<PlayerManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (messageType == MessageType.Forrest && particles) {
			particles.enableEmission = !selected;
		}
	}
}
