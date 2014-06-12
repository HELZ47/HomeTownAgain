using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	//Fields
	public PlayerManager player;
	public GameObject crosshair;
	public GUIText onScreenMessage;
	float messageDisplayTimer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		messageDisplayTimer += Time.deltaTime;
		if (messageDisplayTimer > 5f) {
			onScreenMessage.GetComponent<OnCameraMessage>().appearing = false;
		}


		RaycastHit hit;
		int layerMask = 1 << 10;

		//Display the crosshair if the camera is look at the message object at close distance
		if (Physics.Raycast(transform.position, Vector3.Normalize(crosshair.transform.position - transform.position), out hit, 10, layerMask)) {
			crosshair.renderer.enabled = true;
		} else {
			crosshair.renderer.enabled = false;
		}

		//Press "E" to interact with the message object depending on its type
		if (Input.GetKeyDown(KeyCode.E) && crosshair.renderer.enabled == true) {
			onScreenMessage.text = hit.collider.GetComponent<Message>().message;
			displayMessage();
			hit.collider.GetComponent<Message>().selected = true;
			onScreenMessage.enabled = true;

			if (player.citySmall && hit.collider.GetComponent<Message>().messageType == Message.MessageType.SmallCity) {
				player.smallScaleLimit *= 0.8f;
				if (player.smallScaleLimit < 0.1f) {
					player.smallScaleLimit = 0.1f;
				}
			}

			if (player.cityBig && hit.collider.GetComponent<Message>().messageType == Message.MessageType.BigCity) {
				player.BigScaleLimit *= 1.2f;
				if (player.BigScaleLimit > 15f) {
					player.BigScaleLimit = 15f;
				}
			}

			//onScreenMessage.text = player.smallScaleLimit.ToString ();
		}
	}

	//Display message for a period of time
	void displayMessage () {
		onScreenMessage.GetComponent<OnCameraMessage>().appearing = true;
		messageDisplayTimer = 0;
		player.audioManager.srcMsgActivation.Play ();
	}
}
