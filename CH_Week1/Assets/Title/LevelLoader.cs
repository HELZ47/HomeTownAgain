using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			Application.LoadLevel ("demo");
		}

//		if(Application.GetStreamProgressForLevel("demo") ==1){
//			Application.LoadLevel("demo");
//		}

	}
}
