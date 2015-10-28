using UnityEngine;
using System.Collections;

public class GateCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player")
			GetComponent<AudioSource> ().Play ();
	}
}
