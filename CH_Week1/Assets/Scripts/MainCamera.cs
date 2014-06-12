using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	//Fields
	public PlayerManager player;
	public GameObject crosshair;
	public GUIText onScreenMessage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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
}
