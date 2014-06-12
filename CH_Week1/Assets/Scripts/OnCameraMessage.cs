using UnityEngine;
using System.Collections;

public class OnCameraMessage : MonoBehaviour {

	public GUIText text;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		text.pixelOffset = new Vector2 (Screen.width/2, 0);
	}
}
