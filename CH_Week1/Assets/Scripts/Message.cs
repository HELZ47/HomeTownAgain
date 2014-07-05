using UnityEngine;
using System.Collections;

public class Message : MonoBehaviour {

	PlayerManager player;
	public string message;
	public bool selected;
	public ParticleSystem particles;
	public enum MessageType { Forrest, SmallCity, BigCity };
	public MessageType messageType;
	public Light treeLight;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("First Person Controller").GetComponent<PlayerManager> ();
		particles = GetComponentInChildren<ParticleSystem> ();
		treeLight = GetComponentInChildren<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (messageType == MessageType.Forrest && particles) {
			particles.enableEmission = treeLight.enabled = !selected;
		}
		else if (messageType == MessageType.SmallCity && treeLight) {
			treeLight.enabled = !selected;
		}
		else if (messageType == MessageType.BigCity && treeLight) {
			treeLight.enabled = !selected;
		}
	}
}
