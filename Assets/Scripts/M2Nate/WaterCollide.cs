using UnityEngine;
using System.Collections;

public class WaterCollide : MonoBehaviour {

	public AudioClip footstep;
	public AudioClip waterstep;
	GameObject player;
	AudioSource audi;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
		audi = player.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject == player) {
			audi.clip = waterstep;
			audi.Play();
		}
	}

	void OnTriggerExit(Collider col){
		if (player.GetComponent<Transform> ().position.y < this.GetComponent<Transform> ().position.y) {
			return;
		} else {
			audi.clip = footstep;
			audi.Play();
		}
	}

}
