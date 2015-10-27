//Lanssie

using UnityEngine;
using System.Collections;

public class float_boat : MonoBehaviour {

	public GameObject water;

	public int force;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > water.transform.position.y) {
			GetComponent<Rigidbody>().AddForce(transform.up * force * 10);
		}

		if (transform.position.y < water.transform.position.y) {
			GetComponent<Rigidbody>().AddForce(-transform.up * force * 5);

		}
	}
}
