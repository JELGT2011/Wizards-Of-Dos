using UnityEngine;
using System.Collections;

public class StageSelect : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void LoadJapaneseStage(){
		Application.LoadLevel("JapaneseStage");
	}
	
	public void LoadIceStage(){
		Application.LoadLevel("IceStage");
	}
	public void LoadJungleStage(){
		Application.LoadLevel("JungleStage");
	}
	public void LoadHellStage(){
		Application.LoadLevel("HellStage");
	}
	
}
