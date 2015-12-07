using UnityEngine;
using System.Collections;

public class StageInitialization : MonoBehaviour {
	private GameObject player1Spawn;
	private GameObject player2Spawn;
	private GameObject player1Camera;
	private GameObject player2Camera;
	// Use this for initialization
	void Start () {
		player1Spawn = GameObject.Find("Player1Spawn");
		player2Spawn = GameObject.Find("Player2Spawn");
		player1Camera = GameObject.FindWithTag ("PlayerCam1");
		player2Camera = GameObject.FindWithTag ("PlayerCam2");
		//player1Camera.GetComponent<AutoCam>();
		GameObject player1 = (GameObject)Instantiate(Resources.Load("Characters/" + CharacterSelect.player1Character), 
		                                             player1Spawn.transform.position, player1Spawn.transform.rotation);
		player1.tag = "Player1Char";
		player1Camera.GetComponent<AutoCam>().SetTarget(player1.transform);
		player1.GetComponent<StandardCharacterController>()._playerAssign = "K1";
		
		GameObject player2 = (GameObject)Instantiate(Resources.Load("Characters/" + CharacterSelect.player2Character), 
													 player2Spawn.transform.position, player2Spawn.transform.rotation);
		player2.tag = "Player2Char";
		player2Camera.GetComponent<AutoCam>().SetTarget(player2.transform);
		player2.GetComponent<StandardCharacterController>()._playerAssign = "K2";
		
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
