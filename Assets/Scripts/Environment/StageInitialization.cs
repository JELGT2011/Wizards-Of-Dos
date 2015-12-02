using UnityEngine;
using System.Collections;

public class StageInitialization : MonoBehaviour {
	private GameObject player1Spawn;
	private GameObject player2Spawn;
	private Camera player1Camera;
	private Camera player2Camera;
	// Use this for initialization
	void Start () {
		print (CharacterSelect.player1Character);
		print (CharacterSelect.player2Character);
		player1Spawn = GameObject.Find("Player1Spawn");
		player2Spawn = GameObject.Find("Player2Spawn");
		GameObject player1 = (GameObject)Instantiate(Resources.Load("Characters/" + CharacterSelect.player1Character + "_K1"), player1Spawn.transform.position, 
		player1Spawn.transform.rotation);
		GameObject player2 = (GameObject)Instantiate(Resources.Load("Characters/" + CharacterSelect.player2Character + "_K2"), player2Spawn.transform.position,
		player2Spawn.transform.rotation);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
