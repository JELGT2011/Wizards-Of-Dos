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
		Player = GameObject.FindGameObjectWithTag("Player1");
	}

	void OnCollisionEnter (Collision coll)
	{
		if (coll.gameObject.tag == "Player1" && coll.gameObject.GetComponentInChildren<StandardCharacterController>().IsMoving){
			source.clip = walkSound;
			source.Play ();
		}
	}
	
}