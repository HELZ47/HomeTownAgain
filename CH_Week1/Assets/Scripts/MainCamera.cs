using UnityEngine;
using System.Collections;

public class MainCamera : MonoBehaviour {

	//Fields
	public GameObject crosshair;
	public GUIText onScreenMessage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		int layerMask = 1 << 10;
		if (Physics.Raycast(transform.position, Vector3.Normalize(crosshair.transform.position - transform.position), out hit, 20, layerMask)) {
			crosshair.renderer.enabled = true;
			//Debug.DrawRay(transform.position, Vector3.Normalize(crosshair.transform.position - transform.position) * hit.distance, Color.yellow);
			//print("Did Hit");
		} else {
			crosshair.renderer.enabled = false;
			//Debug.DrawRay(transform.position, Vector3.Normalize(crosshair.transform.position - transform.position) * 50f, Color.red);
			//print("Did not Hit");
		}

		if (Input.GetKeyDown(KeyCode.E) && crosshair.renderer.enabled == true) {
			onScreenMessage.text = hit.collider.GetComponent<Message>().message;
			hit.collider.GetComponent<Message>().selected = true;
			onScreenMessage.enabled = true;
		}
	}
}
