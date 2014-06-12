using UnityEngine;
using System.Collections;

public class OnCameraMessage : MonoBehaviour {

	public GUIText text;
	
	public bool appearing;
	public float fadeRate;

	// Use this for initialization
	void Start () {
		appearing = false;
		fadeRate = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
		text.pixelOffset = new Vector2 (Screen.width/2, 0);
		if (appearing && text.color.a < 255) {
			Color textColor = text.color;
			textColor.a += fadeRate;
			text.color = textColor;
		}
		else if (!appearing && text.color.a > 0) {
			Color textColor = text.color;
			textColor.a -= fadeRate;
			text.color = textColor;
		}
	}
}
