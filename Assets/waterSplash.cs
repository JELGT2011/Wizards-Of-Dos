//Lanssie 

using UnityEngine;
using System.Collections;

public class waterSplash : MonoBehaviour {

	ParticleSystem hitParticles;
	MeshCollider meshCollider;
	public AudioSource audioSource;
	AudioClip waterStep;
	GameObject player;

	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		waterStep = (AudioClip)Resources.Load ("Audio/water_step");
//		audioSource.clip = waterStep;
//		audioSource.Play ();

	}
	
	// Update is called once per frame
	void onTriggerEnter(Collider col) {
		//check if collider is triggered
		//if yes, play particles and play sound. 
			audioSource.clip = waterStep;
			audioSource.pitch = 1f; //Increase the pitch to increase speed of audio clip
			audioSource.Play ();
	}

	void onTriggerExit(Collider col){
		audioSource.clip = waterStep;
		audioSource.pitch = 1f; //Increase the pitch to increase speed of audio clip

		audioSource.Stop();
	}
}
