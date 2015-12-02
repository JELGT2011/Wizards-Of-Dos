using UnityEngine;
using System.Collections;

public class CharacterSelect : MonoBehaviour {

	Transform player1;
	Transform player2;
	public string[] characters = {"Ekko", "Ninja", "Tora"};
	int player1Index;
	int player2Index;
	public static string player1Character;
	public static string player2Character;
	private bool player1AxisInUse = false;
	private bool player2AxisInUse = false;
	
	// Use this for initialization
	void Start () {
		Transform[] players = GetComponentsInChildren<Transform>();
		player1 = players[1];
		player2 = players[2];
		player1Index = 0;
		player2Index = 0;
	}
	
	// Update is called once per frame
	void Update () {
		float player1Keyboard = Input.GetAxis("K1_Horizontal");
		float player1Joystick = Input.GetAxis("J1_Horizontal");
		float player2Keyboard = Input.GetAxis("K2_Horizontal");
		float player2Joystick = Input.GetAxis("J2_Horizontal");
		
		if(player1Keyboard != 0)
		{
			if(player1AxisInUse == false)
			{
				if(player1Keyboard < 0 && player1Index > 0){
					player1Index -= 1;
					player1.position = new Vector3(player1.position.x - 5, player1.position.y, player1.position.z);
				}
				else if(player1Keyboard > 0 && player1Index < characters.Length-1){
					player1Index += 1;
					player1.position = new Vector3(player1.position.x + 5, player1.position.y, player1.position.z);
				}
				player1AxisInUse = true;
			}
		}
		else if(player1Joystick != 0){
			if(player1AxisInUse == false)
			{
				if(player1Joystick < 0 && player1Index > 0){
					player1Index -= 1;
					player1.position = new Vector3(player1.position.x - 5, player1.position.y, player1.position.z);
				}
				else if(player1Joystick > 0 && player1Index < characters.Length-1){
					player1Index += 1;
					player1.position = new Vector3(player1.position.x + 5, player1.position.y, player1.position.z);
				}
				player1AxisInUse = true;
			}
		}
		else{
			player1AxisInUse = false;
		}
		
		if(player2Keyboard != 0)
		{
			if(player2AxisInUse == false)
			{
				if(player2Keyboard < 0 && player2Index > 0){
					player2Index -= 1;
					player2.position = new Vector3(player2.position.x - 5, player2.position.y, player2.position.z);
				}
				else if(player2Keyboard > 0 && player2Index < characters.Length-1){
					player2Index += 1;
					player2.position = new Vector3(player2.position.x + 5, player2.position.y, player2.position.z);
				}
				player2AxisInUse = true;
			}
		}
		else if(player2Joystick != 0){
			if(player2AxisInUse == false)
			{
				if(player2Joystick < 0 && player2Index > 0){
					player2Index -= 1;
					player2.position = new Vector3(player2.position.x - 5, player2.position.y, player2.position.z);
				}
				else if(player1Joystick > 0 && player1Index <= characters.Length-1){
					player2Index += 1;
					player2.position = new Vector3(player2.position.x + 5, player2.position.y, player2.position.z);
				}
				player2AxisInUse = true;
			}
		}
		else{
			player2AxisInUse = false;
		}
	}
	
	public void LoadStageSelect(){
		Application.LoadLevel("StageSelect");
		player1Character = characters[player1Index];
		player2Character = characters[player2Index];
	}
}
