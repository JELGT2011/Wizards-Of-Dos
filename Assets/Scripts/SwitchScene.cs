using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {

	// Use this for initialization
	void Awake () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			Debug.Log ("called");
			Application.LoadLevel(0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			Application.LoadLevel(1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			Application.LoadLevel(2);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			Application.LoadLevel(3);
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			Application.LoadLevel(4);
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			Application.LoadLevel(5);
		}
	}
}
