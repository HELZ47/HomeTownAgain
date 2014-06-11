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

		//Set the parameters
		speed = 25f;
		normalCameraHeight = 1.8f;
		lowCameraHeight = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {

		//Move the player according to the keyboard inputs
		CheckInputs ();

		//If the player's velocity is smaller than 1, the player's not moving
		if (rigidbody.velocity.magnitude <= 1) {
			isMoving = false;
		}
		else {
			isMoving = true;
		}

		//If the player moves, trees around it move, else trees change direction
		int movingTreeLayer = 1 << 9;
		if (isMoving) {
			foreach (Collider col in Physics.OverlapSphere (transform.position, 35, movingTreeLayer)) {
				if (col.GetComponent<Tree>()) {
					col.GetComponent<Tree>().MoveTree ();
				}
			}
		}
		else {
			foreach (Collider col in Physics.OverlapSphere (transform.position, 35, movingTreeLayer)) {
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
	void CheckInputs () {
		if (Input.GetKey(KeyCode.W)) {
			rigidbody.AddForce (transform.forward*(camera.transform.position.y*1.5f/normalCameraHeight)*Time.deltaTime*speed, ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.S)) {
			rigidbody.AddForce (-transform.forward*Time.deltaTime*speed, ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.A)) {
			rigidbody.AddForce (-transform.right*Time.deltaTime*speed, ForceMode.VelocityChange);
		}
		if (Input.GetKey(KeyCode.D)) {
			rigidbody.AddForce (transform.right*Time.deltaTime*speed, ForceMode.VelocityChange);
		}
		if (Input.GetKey (KeyCode.U)) {
			lowerCamera = true;
		}
		if (Input.GetKey (KeyCode.J)) {
			increaseCamera = true;
		}
	}
}
