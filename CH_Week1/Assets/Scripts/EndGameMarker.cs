using UnityEngine;
using System.Collections;

public class EndGameMarker : MonoBehaviour {

	//Fields
	public GameObject player;

	// Use this for initialization
	void Start () {
		print ("Hello!");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Magnitude(player.transform.position - transform.position) < 1.5f) {
			Application.LoadLevel ("Title");
		}
		print (Vector3.Magnitude (player.transform.position - transform.position));
		print ("Hello!");
	}
}
