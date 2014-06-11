using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	//Fields
	public float speed;
	public bool lowerCamera, increaseCamera, isMoving;
	public Camera camera;
	float normalCameraHeight, lowCameraHeight;

	// Use this for initialization
	void Start () {
		//Hide the mouse cursor
		Screen.showCursor = false;

		//Set the walking speed to 5
		speed = 5f;
		normalCameraHeight = 1.8f;
		lowCameraHeight = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		//print (camera.transform.position);
		isMoving = CheckInputs ();
		//print (isMoving);

		if (isMoving) {
			foreach (Collider col in Physics.OverlapSphere (transform.position, 35, 1001)) {
				if (col.GetComponent<Tree>()) {
					col.GetComponent<Tree>().MoveTree ();
				}
			}
		}
		else {
			foreach (Collider col in Physics.OverlapSphere (transform.position, 35, 1001)) {
				if (col.GetComponent<Tree>()) {
					col.GetComponent<Tree>().GenerateDirection ();
				}
			}
		}







		if (lowerCamera) {
			if (camera.transform.position.y > lowCameraHeight) {
				camera.transform.position = camera.transform.position + new Vector3(0, -0.01f, 0);
				camera.fieldOfView -= 0.3f;
				if (camera.fieldOfView < 30) {
					camera.fieldOfView = 30;
				}
			}
			else {
				//camera.transform.position.y = 0.5f;
				lowerCamera = false;
				camera.fieldOfView = 30;
			}
		}
		else if (increaseCamera) {
			if (camera.transform.position.y < normalCameraHeight) {
				camera.transform.position = camera.transform.position + new Vector3(0, 0.01f, 0);
				camera.fieldOfView += 0.3f;
				if (camera.fieldOfView > 60) {
					camera.fieldOfView = 60;
				}
			}
			else {
				//camera.transform.position.y = 0.5f;
				increaseCamera = false;
				camera.fieldOfView = 60;
			}
		}
	}


	//Check keyboard (or other) inputs
	bool CheckInputs () {
		if (Input.GetKey(KeyCode.W)) {
			rigidbody.AddForce (transform.forward*(camera.transform.position.y*1.5f/normalCameraHeight), ForceMode.VelocityChange);
			return true;
		}
		if (Input.GetKey(KeyCode.S)) {
			rigidbody.AddForce (-transform.forward, ForceMode.VelocityChange);
			return true;
		}
		if (Input.GetKey(KeyCode.A)) {
			rigidbody.AddForce (-transform.right, ForceMode.VelocityChange);
			return true;
		}
		if (Input.GetKey(KeyCode.D)) {
			rigidbody.AddForce (transform.right, ForceMode.VelocityChange);
			return true;
		}
		if (Input.GetKey (KeyCode.U)) {
			lowerCamera = true;
		}
		if (Input.GetKey (KeyCode.J)) {
			increaseCamera = true;
		}
		return false;
	}
}
