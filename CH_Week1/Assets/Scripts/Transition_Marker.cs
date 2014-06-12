﻿using UnityEngine;
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
		if (Vector3.Magnitude (player.transform.position - transform.position) < 2.5f) {
			player.GetComponent<PlayerManager>().citySmall = true;
			player.GetComponent<PlayerManager>().mainCamera.GetComponent<MainCamera>().onScreenMessage.text = "new Level!";
			player.GetComponent<PlayerManager>().mainCamera.GetComponent<MainCamera>().onScreenMessage.enabled = true;
			if (doorTree.transform.position.x != doorDestination.transform.position.x) {
				Vector3 tempPosition = doorTree.transform.position;
				tempPosition.x = doorDestination.transform.position.x;
				tempPosition.z = doorDestination.transform.position.z;
				doorTree.transform.position = tempPosition;
			}
		}
	}
}
