using UnityEngine;
using System.Collections;

public class GenerateBottles : MonoBehaviour {

	public GameObject bottleObj;
	Transform trans;
	void Awake () {
		trans = GameObject.FindGameObjectWithTag ("Player").GetComponent<Transform> ();
		InvokeRepeating ("PutNewBottle", 2, 5);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PutNewBottle(){
		Vector3 pos = new Vector3 (Random.Range (trans.position.x - 10f, trans.position.x + 10f), trans.position.y+0.5f, Random.Range (trans.position.z - 10f, trans.position.z + 10f));
		Instantiate (bottleObj, pos, trans.rotation);
	}
}
