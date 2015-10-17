using UnityEngine;
using System.Collections;

public class open_chest : MonoBehaviour {

	Animator anim;
	GameObject player;
	GameObject door;
	Animation o_chest;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void onCollisionEnter (Collider col) {
		if (col.gameObject == player) {
			o_chest.Play("open");
		}
		//GetComponent.<Animation>().Play("open");
		//yield WaitForSeconds (1.75);
		//GetComponent.<Animation>().Play("close");
	}
}
