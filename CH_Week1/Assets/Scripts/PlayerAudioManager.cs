using UnityEngine;
using System.Collections;

public class PlayerAudioManager : MonoBehaviour {

	//Audio sources
	public AudioSource srcMsgActivation;
	public AudioSource srcTreeRustling;
	
	//Audio source variables
	public float rustlingTargetVol;
	public float rustlingLerpRate;
	
	//Audio clips
	public AudioClip clipForestMsg;
	public AudioClip clipTownMsg;
	
	// Use this for initialization
	void Start () {
		srcMsgActivation.clip = clipForestMsg;
		srcMsgActivation.volume = 0.5f;
		
		rustlingTargetVol = 0.0f;
		rustlingLerpRate = 0.1f;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Mathf.Abs (rustlingTargetVol - srcTreeRustling.volume) < 0.1f) {
			srcTreeRustling.volume = rustlingTargetVol;
		}
		else {
			srcTreeRustling.volume = Mathf.Lerp (srcTreeRustling.volume, rustlingTargetVol, rustlingLerpRate);
		}	
	
	}
	
}
