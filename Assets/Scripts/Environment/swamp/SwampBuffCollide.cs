using UnityEngine;
using System.Collections;

public class SwampBuffCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

	void OnTriggerEnter(Collider col){
		if ((col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2") && !col.gameObject.GetComponent<CharacterStats>().HasBuff("BigTreeGrace")) {
			col.gameObject.GetComponent<CharacterStats> ().AddBuff ("BigTreeGrace", 5f);
			Destroy (this.gameObject, 0.5f);
		}
	}
}
