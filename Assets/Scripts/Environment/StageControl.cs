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
	public float collpaseInterval = 1f;

	int numOfBlock;
	List<GameObject> list;
	GameObject[] blocks;
	int index;

	void Awake () {
		numOfBlock = scaleX * scaleZ;
		index = 0;
		list = new List<GameObject>();
		GenBlocks ();
		blocks = list.OrderByDescending (item => item.transform.position.sqrMagnitude).ToArray (); // outmost block will fall if randomness is 0 (no shuffle)
		if (randomness == 1f)
			ShuffleArray ();
		else if(randomness > 0f){
			ShuffleArray ();
		}
		InvokeRepeating ("CollapseNext", collpaseInterval, collpaseInterval);
	}

	void FixedUpdate () {

	}

	void GenBlocks(){
		Vector3 pos = new Vector3 ();
		pos.x = -(scaleX / 2-0.5f) * blockModel.GetComponent<MeshRenderer> ().bounds.size.x;
		pos.z = -(scaleZ / 2-0.5f) * blockModel.GetComponent<MeshRenderer> ().bounds.size.z;
		pos.y = 0;
		for (int i = 1; i <= numOfBlock; i++) {
			GameObject obj = (GameObject)Instantiate(blockModel, pos, new Quaternion());
			list.Add(obj);
			if(i % scaleX == 0){
				pos.z += blockModel.GetComponent<MeshRenderer> ().bounds.size.z;
				pos.x = -(scaleX / 2-0.5f) * blockModel.GetComponent<MeshRenderer> ().bounds.size.x;
			}
			else{
				pos.x+=blockModel.GetComponent<MeshRenderer> ().bounds.size.x;
			}
			pos = new Vector3(pos.x, pos.y, pos.z);
		}
	}

	void CollapseNext(){
		Rigidbody rb = blocks [index].AddComponent<Rigidbody>();
		rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
		rb.useGravity = true;
		Destroy (blocks [index++], 3); // destroy after 3 seconds
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

