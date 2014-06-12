﻿using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour {

	//Fields
	bool increaseSize;
	float xForce, zForce;
	Vector3 prevPosition, currentPosition;

	// Use this for initialization
	void Start () {
		prevPosition = transform.position;
		//xForce = Random.Range (-3f, 3f);
//		zForce = Random.Range (-3f, 3f);
		GenerateDirection ();
	}
	
	// Update is called once per frame
	void Update () {
		currentPosition = transform.position;
		if (Input.GetKey(KeyCode.I)) {
			increaseSize = true;
//			Vector3 temp = transform.localScale;
//			temp.y += 0.03f;
//			temp.x += 0.01f;
//			temp.z += 0.01f;
//			transform.localScale = temp;
		}

		if (increaseSize && transform.localScale.y < 3) {
			Vector3 temp = transform.localScale;
			temp.y += 0.05f;
			temp.x += 0.03f;
			temp.z += 0.03f;
			//temp += Vector3.one * Time.deltaTime;
			transform.localScale = temp;
		}
		else {
			increaseSize = false;
		}

		if (currentPosition != prevPosition) {
			int layer9 = 1 << 9;
			if (Physics.CheckSphere (currentPosition, 1, layer9)) {
				currentPosition = prevPosition;
			}
			else {
				prevPosition = currentPosition;
			}
		}

		//rigidbody.AddForce (xForce, 0, zForce);
	}

	public void GenerateDirection () {
		xForce = Random.Range (-1f, 1f) * 5f;
		zForce = Random.Range (-1f, 1f) * 5f;
		if (rigidbody.velocity.magnitude > 10) {
			rigidbody.velocity = rigidbody.velocity.normalized * 9.5f;
		}
	}

	public void MoveTree () {
		rigidbody.AddForce (xForce, 0, zForce, ForceMode.Acceleration);
	}
}
