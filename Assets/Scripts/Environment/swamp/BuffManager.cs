using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuffManager : MonoBehaviour {

	protected Dictionary<string, float> buffList; //buff name, durations
	// Use this for initialization
	void Awake () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	public void AddBuff(string name, float duration){
		buffList.Add (name, duration);
	}
	
	public void RemoveBuff(string name){
		if (buffList.ContainsKey (name))
			buffList.Remove (name);
	}
	
	public bool HasBuff(string name){
		if (buffList.ContainsKey (name) && buffList [name] <= 0)
			buffList.Remove (name);
		return buffList.ContainsKey(name);
	}
}
