using UnityEngine;
using System.Collections;

public class SwampBuffCollide : MonoBehaviour {
	public GameObject buffEffect;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

	void OnTriggerEnter(Collider col){
		if ((col.gameObject.tag == "Player1" || col.gameObject.tag == "Player2") && !col.gameObject.GetComponent<CharacterStats>().HasBuff("BigTreeGrace")) {
			col.gameObject.GetComponent<CharacterStats> ().AddBuff ("BigTreeGrace", 10f);
			GameObject buff = (GameObject) Instantiate(buffEffect, new Vector3(0f, 0f, 0f), new Quaternion());
			buff.transform.parent = col.gameObject.transform;
			buff.transform.position = new Vector3(col.gameObject.transform.position.x, col.gameObject.transform.position.y+2f, col.gameObject.transform.position.z);
			buff.transform.localScale = new Vector3(0.5f, 1f, 0.5f);
			Destroy (this.gameObject, 0.5f);
		}
	}
}
