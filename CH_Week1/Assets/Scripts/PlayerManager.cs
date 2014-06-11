using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {

	//Fields
	public float speed;
	public bool lowerCamera, increaseCamera, isMoving;
	public Camera mainCamera;
	float normalCameraHeight, lowCameraHeight;
	public bool citySmall, cityBig;
	public float smallScaleLimit, BigScaleLimit;

	// Use this for initialization
	void Start () {
		//Hide the mouse cursor
		Screen.showCursor = false;

		//Set the parameters
		speed = 25f;
		normalCameraHeight = 1.8f;
		lowCameraHeight = 0.5f;
		smallScaleLimit = 0.5f;
		BigScaleLimit = 3.5f;
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
			if (isMoving) {
				transform.localScale -= new Vector3(0.0005f, 0.0005f, 0.0005f);
				if (transform.localScale.magnitude < smallScaleLimit) {
					transform.localScale = transform.localScale.normalized * smallScaleLimit;
				}
			}
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
			if (mainCamera.transform.position.y > lowCameraHeight) {
				mainCamera.transform.position = mainCamera.transform.position + new Vector3(0, -0.01f, 0);
				mainCamera.fieldOfView -= 0.3f;
				if (mainCamera.fieldOfView < 30) {
					mainCamera.fieldOfView = 30;
				}
			}
			else {
				//camera.transform.position.y = 0.5f;
				lowerCamera = false;
				mainCamera.fieldOfView = 30;
			}
		}
		else if (increaseCamera) {
			if (mainCamera.transform.position.y < normalCameraHeight) {
				mainCamera.transform.position = mainCamera.transform.position + new Vector3(0, 0.01f, 0);
				mainCamera.fieldOfView += 0.3f;
				if (mainCamera.fieldOfView > 60) {
					mainCamera.fieldOfView = 60;
				}
			}
			else {
				//camera.transform.position.y = 0.5f;
				increaseCamera = false;
				mainCamera.fieldOfView = 60;
			}
		}
	}


	//Check keyboard (or other) inputs
	void CheckInputs () {
		if (Input.GetKey(KeyCode.W)) {
			rigidbody.AddForce (transform.forward/*(mainCamera.transform.position.y*1.5f/normalCameraHeight)*/*Time.deltaTime*speed, ForceMode.VelocityChange);
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
