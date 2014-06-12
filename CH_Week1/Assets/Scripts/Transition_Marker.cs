﻿using UnityEngine;
using System.Collections;

public class Transition_Marker : MonoBehaviour {

	//Field
	public GameObject player;
	public GameObject doorTree;
	public GameObject doorDestination;
	public enum TransitionType { SmallCity, BigCity };
	public TransitionType transitionType;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transitionType == TransitionType.SmallCity) {
			if (Vector3.Magnitude (player.transform.position - transform.position) < 2.5f) {
				player.GetComponent<PlayerManager>().citySmall = true;
				player.GetComponent<PlayerManager>().mainCamera.GetComponent<MainCamera>().onScreenMessage.text = "small city";
				player.GetComponent<PlayerManager>().mainCamera.GetComponent<MainCamera>().onScreenMessage.enabled = true;
				if (doorTree.transform.position.x != doorDestination.transform.position.x) {
					Vector3 tempPosition = doorTree.transform.position;
					tempPosition.x = doorDestination.transform.position.x;
					tempPosition.z = doorDestination.transform.position.z;
					doorTree.transform.position = tempPosition;
				}
				player.GetComponent<PlayerManager>().audioManager.srcMsgActivation.clip = player.GetComponent<PlayerManager>().audioManager.clipTownMsg;
				player.GetComponent<PlayerManager>().audioManager.bgForestBirdsTargetVol = 0.0f;
				player.GetComponent<PlayerManager>().audioManager.bgForestWindTargetVol = 0.0f;
				player.GetComponent<PlayerManager>().audioManager.bgTownTargetVol = 1.0f;
			}
		}

		if (transitionType == TransitionType.BigCity) {
			if (Vector3.Magnitude (player.transform.position - transform.position) < 2.5f) {
				player.GetComponent<PlayerManager>().cityBig = true;
				player.GetComponent<PlayerManager>().citySmall = false;
				player.GetComponent<PlayerManager>().mainCamera.GetComponent<MainCamera>().onScreenMessage.text = "big city";
				player.GetComponent<PlayerManager>().mainCamera.GetComponent<MainCamera>().onScreenMessage.enabled = true;
//				if (doorTree.transform.position.x != doorDestination.transform.position.x) {
//					Vector3 tempPosition = doorTree.transform.position;
//					tempPosition.x = doorDestination.transform.position.x;
//					tempPosition.z = doorDestination.transform.position.z;
//					doorTree.transform.position = tempPosition;
//				}
				player.GetComponent<PlayerManager>().audioManager.srcMsgActivation.clip = player.GetComponent<PlayerManager>().audioManager.clipCityMsg;
				player.GetComponent<PlayerManager>().audioManager.bgForestBirdsTargetVol = 0.0f;
				player.GetComponent<PlayerManager>().audioManager.bgForestWindTargetVol = 0.0f;
				player.GetComponent<PlayerManager>().audioManager.bgTownTargetVol = 1.0f;
			}
		}
	}
}
