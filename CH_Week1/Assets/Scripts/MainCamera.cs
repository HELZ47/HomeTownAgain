using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	//Fields
	public PlayerManager player;
	//public GameObject crosshair;
	public GUIText crosshair, crosshair_target;
	public GUIText onScreenMessage;
	float messageDisplayTimer;

	// Use this for initialization
	void Start () {
		onScreenMessage.GetComponent<OnCameraMessage>().appearing = false;
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		int layerMask = 1 << 10;

		messageDisplayTimer += Time.deltaTime;
		if (!Physics.Raycast(transform.position, transform.forward, out hit, 13, layerMask) && messageDisplayTimer > 5f) {
			onScreenMessage.GetComponent<OnCameraMessage>().appearing = false;
		}


		//Display the crosshair if the camera is look at the message object at close distance
		if (Physics.Raycast(transform.position, transform.forward, out hit, 13, layerMask)) {
			//if (hit.collider.GetComponent<Message>().messageType == Message.MessageType.Forrest) {
				crosshair.enabled = true;
			//}
			crosshair_target.enabled = true;
		} else {
			crosshair.enabled = false;
			crosshair_target.enabled = false;
		}

		//Press "E" to interact with the message object depending on its type
		if ((Input.GetKeyDown(KeyCode.E) || Input.GetMouseButton(0) ) && crosshair_target.enabled == true) {
			onScreenMessage.text = hit.collider.GetComponent<Message>().message;
			displayMessage();

			onScreenMessage.enabled = true;

			if (player.citySmall && hit.collider.GetComponent<Message>().messageType == Message.MessageType.SmallCity && hit.collider.GetComponent<Message>().selected == false) {
				player.smallScaleLimit *= 0.8f;
				if (player.smallScaleLimit < 0.1f) {
					player.smallScaleLimit = 0.1f;
				}
			}

			if (player.cityBig && hit.collider.GetComponent<Message>().messageType == Message.MessageType.BigCity && hit.collider.GetComponent<Message>().selected == false) {
				player.BigScaleLimit *= 1.2f;
				if (player.BigScaleLimit > 15f) {
					player.BigScaleLimit = 15f;
				}
			}
			hit.collider.GetComponent<Message>().selected = true;
			//onScreenMessage.text = player.smallScaleLimit.ToString ();
		}

		if (onScreenMessage.GetComponent<OnCameraMessage>().appearing) {
			crosshair.enabled = false;
			crosshair_target.enabled = false;
		}
	}

	//Display message for a period of time
	void displayMessage () {
		onScreenMessage.GetComponent<OnCameraMessage>().appearing = true;
		messageDisplayTimer = 0;
		player.audioManager.srcMsgActivation.Play ();
	}
}
