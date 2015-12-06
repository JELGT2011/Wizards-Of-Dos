using UnityEngine;
using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;

public class StageControl : MonoBehaviour {

	public int scaleX = 10; //num of blocks on x axis
	public int scaleZ = 10; //num of blocks on z axis
	public float randomness = 0.5f; //range from 0.0 to 1.0
	public GameObject blockModel;
	public float collpaseInterval = 1.8f;

	int numOfBlock;
	List<GameObject> list;
	GameObject[] blocks;
	int index;
	Dictionary<Transform, int> blocksToRise;

	void Awake () {
		numOfBlock = scaleX * scaleZ;
		index = 0;
		list = new List<GameObject>();
		blocksToRise = new Dictionary<Transform, int> ();
		GenBlocks ();
		blocks = list.OrderByDescending (item => item.transform.position.sqrMagnitude).ToArray (); // outmost block will fall if randomness is 0 (no shuffle)
		SetupPlayers ();
		if (randomness == 1f)
			ShuffleArray ();
		else if(randomness > 0f){
			ShuffleArray ();
		}
		Invoke("initCollapse", 10f);
	}

	void FixedUpdate () {
		foreach (KeyValuePair<Transform, int> entry in blocksToRise) {
			if(entry.Key.position.y < entry.Value){
				entry.Key.position = new Vector3(entry.Key.position.x, entry.Key.position.y+0.25f, entry.Key.position.z);
			}
			else{
				blocksToRise.Remove(entry.Key);
			}
		}
	}

	void GenBlocks(){
		Vector3 pos = new Vector3 ();
		pos.x = -(scaleX / 2-0.5f) * blockModel.GetComponent<MeshRenderer> ().bounds.size.x;
		pos.z = -(scaleZ / 2-0.5f) * blockModel.GetComponent<MeshRenderer> ().bounds.size.z;
		pos.y = 0;
		for (int i = 1; i <= numOfBlock; i++) {
			GameObject obj = (GameObject)Instantiate(blockModel, pos, new Quaternion());
			if(i % scaleX == 0){
				pos.z += blockModel.GetComponent<MeshRenderer> ().bounds.size.z;
				pos.x = -(scaleX / 2-0.5f) * blockModel.GetComponent<MeshRenderer> ().bounds.size.x;
			}
			else{
				pos.x+=blockModel.GetComponent<MeshRenderer> ().bounds.size.x;
			}
			//pos.y = UnityEngine.Random.Range(0,100) >= 90 ? UnityEngine.Random.Range(2, 5) : 0;
			pos.y = 0;
			list.Add(obj);
			pos = new Vector3(pos.x, pos.y, pos.z);
		}
	}

	void SetupPlayers(){
		GameObject p1 = GameObject.FindGameObjectWithTag("Player1");
		GameObject p2 = GameObject.FindGameObjectWithTag("Player2");
		p1.GetComponent<Transform> ().position = blocks [UnityEngine.Random.Range (0, 50)].GetComponent<Transform> ().position;
		p2.GetComponent<Transform> ().position = blocks [UnityEngine.Random.Range (50, 100)].GetComponent<Transform> ().position;

	}

	void initCollapse(){
		InvokeRepeating ("CollapseNext", collpaseInterval, collpaseInterval);
	}

	void CollapseNext(){
		int rand = UnityEngine.Random.Range (0, 100);
		if (rand >= 80) {
				blocksToRise.Add(blocks[index++].GetComponent<Transform>(), UnityEngine.Random.Range(3,6));
		} else {
			Rigidbody rb = blocks [index].AddComponent<Rigidbody> ();
			rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
			rb.useGravity = true;
			Destroy (blocks [index++], 3); // destroy after 3 seconds
		}
	}

	void ShuffleArray(){
		int n = blocks.Length; 
		int bound = n - (int)Math.Floor (randomness * n) + 1;
		while (n > bound) {  
			n--;  
			int k = UnityEngine.Random.Range(0, n + 1);  
			GameObject value = blocks[k];  
			blocks[k] = blocks[n];  
			blocks[n] = value;  
		}  
	}
}

