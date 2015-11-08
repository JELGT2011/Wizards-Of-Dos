using UnityEngine;
using System.Collections;

public class WalkingSound : MonoBehaviour {
	
	public AudioClip walkSound;

	private AudioSource source;
	 
	private GameObject Player; 

	void Awake () {
		if (GameObject.FindGameObjectWithTag("Japan")){
			walkSound = (AudioClip)Resources.Load("Audio/Footstep_J");
		}
		else if (GameObject.FindGameObjectWithTag("Snow")){
			walkSound = (AudioClip)Resources.Load("Audio/snow_step");
		}
		source = GetComponent<AudioSource>();
		Player = GameObject.FindGameObjectWithTag("Player");
	}

	void OnCollisionEnter (Collision coll)
	{
		if (coll.gameObject.tag == "Player" && coll.gameObject.GetComponentInChildren<StandardCharacterController>().isMoving){
			source.clip = walkSound;
			source.Play ();
		}
	}
	
}