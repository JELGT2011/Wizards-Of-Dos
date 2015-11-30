using UnityEngine;
using System.Collections;

public class SwampDebuff : MonoBehaviour {

	public int swampDamage = 10;
	public float damageInterval = 1f;	

	float timer;

	// Use this for initialization
	void Awake () {
		timer = damageInterval;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer -= Time.deltaTime;
	}
	
	void OnTriggerStay(Collider collider){
		CharacterStats stats = collider.gameObject.GetComponent<CharacterStats> (); //is this triggered multiple times?
		if (!stats.HasBuff ("BigOakGrace")) {
			if(timer < 0){
				stats.TakeDamage(swampDamage);
				timer = damageInterval - (0 - timer);
			}
		}
	}
}
