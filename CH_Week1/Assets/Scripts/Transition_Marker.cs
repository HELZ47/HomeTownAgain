using UnityEngine;
using System.Collections;

public class Transition_Marker : MonoBehaviour {

	//Field
	public GameObject player;
	public GameObject doorTree;
	public GameObject doorDestination;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Magnitude (player.transform.position - transform.position) < 5f) {
			if (doorTree.transform.position != doorDestination.transform.position) {
				doorTree.transform.position = doorDestination.transform.position;
			}
		}
	}
}
