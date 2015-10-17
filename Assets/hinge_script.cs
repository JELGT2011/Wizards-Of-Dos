//Lanssie

using UnityEngine;
using System.Collections;

public class hinge_script : MonoBehaviour {

	public float forceAmount = 1000f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onCollisionEnter (Collision col){
		GetComponent<Rigidbody>().AddForce (-transform.forward * forceAmount, ForceMode.Acceleration);
		GetComponent<Rigidbody>().useGravity = true;
	}
}
