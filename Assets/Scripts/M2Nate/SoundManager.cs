using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	AudioSource footstep;
	Animator charAnim;
	
	void Awake () {
		charAnim = GetComponent<Animator> ();
		footstep = GetComponent<AudioSource> ();
		//Debug.Log (river.GetComponent<BoxCollider> ());
	}
	
	// Update is called once per frame
	void Update () {
		if(!charAnim.GetBool ("Moving") || !charAnim.GetBool ("Running")) {
			footstep.Play(); 
		}
	}
	
}
