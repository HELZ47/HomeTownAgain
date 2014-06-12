using UnityEngine;
using System.Collections;

public class PlayerAudioManager : MonoBehaviour {

	//Audio sources
	public AudioSource srcMsgActivation;
	public AudioSource srcTreeRustling;
	public AudioSource srcBGForestBirds;
	public AudioSource srcBGForestWind;
	public AudioSource srcBGTown;
	public AudioSource srcBGCity;
			
	//Audio source variables
	public float rustlingTargetVol;
	public float rustlingLerpRate;
	public float bgLerpRate;	
	public float bgForestBirdsTargetVol;
	public float bgForestWindTargetVol;
	public float bgTownTargetVol;
	public float bgCityTargetVol;
	
	//Audio clips
	public AudioClip clipForestMsg;
	public AudioClip clipTownMsg;
	public AudioClip clipCityMsg;
	
	// Use this for initialization
	void Start () {
		srcMsgActivation.clip = clipForestMsg;
		srcMsgActivation.volume = 0.5f;
		
		rustlingTargetVol = 0.0f;
		rustlingLerpRate = 0.05f;
		bgLerpRate = 0.1f;
		bgForestBirdsTargetVol = 1.0f;
		bgForestWindTargetVol = 1.0f;
		bgTownTargetVol = 0.0f;
		bgCityTargetVol = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		AdjustVolume (srcTreeRustling, rustlingTargetVol, rustlingLerpRate);
		AdjustVolume (srcBGForestBirds, bgForestBirdsTargetVol, bgLerpRate);
		AdjustVolume (srcBGForestWind, bgForestWindTargetVol, bgLerpRate);
		AdjustVolume (srcBGTown, bgTownTargetVol, bgLerpRate);
		AdjustVolume (srcBGCity, bgCityTargetVol, bgLerpRate);
	}
	
	void AdjustVolume (AudioSource source, float targetVol, float lerpRate) {
		if (Mathf.Abs (targetVol - source.volume) < 0.1f) {
			source.volume = targetVol;
		}
		else {
			source.volume = Mathf.Lerp (source.volume, targetVol, lerpRate);
		}
	}
}
