using UnityEngine;
using System.Collections;

public class SwampDebuff : MonoBehaviour {

	float timer;

	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}
	
	void OnTriggerEnter(Collider collider){
		if (!collider.gameObject.tag.Equals("Player1")&& !collider.gameObject.tag.Equals("Player2"))
			return;
		CharacterStats stats = collider.gameObject.GetComponent<CharacterStats> (); //is this triggered multiple times?
		if (!stats.HasBuff ("BigOakGrace") && !stats.HasBuff("SwampDamage")) {
			stats.AddBuff("SwampDamage", 2f);
		}
	}
	void OnTriggerExit(Collider collider){
		CharacterStats stats = collider.gameObject.GetComponent<CharacterStats> (); //is this triggered multiple times?
		if (stats.HasBuff("SwampDamage")) {
			stats.RemoveBuff("SwampDamage");
		}
	}
}
