using UnityEngine;
using System.Collections;

public class StageInitialization : MonoBehaviour
{

    protected Transform player1Spawn;
    protected Transform player2Spawn;
    protected Object character1;
    protected Object character2;
    protected GameObject player1Camera;
    protected GameObject player2Camera;

    void Start()
    {
        player1Spawn = GameObject.Find("Player1Spawn").transform;
        player2Spawn = GameObject.Find("Player2Spawn").transform;
        player1Camera = GameObject.FindWithTag("PlayerCam1");
        player2Camera = GameObject.FindWithTag("PlayerCam2");

        character1 = Resources.Load("Characters/" + (CharacterSelect.player1Character ?? "Ekko"));
        GameObject player1 = (GameObject) Instantiate(character1, player1Spawn.position, player1Spawn.rotation);

        player1.tag = "Player1";
        player1Camera.GetComponent<AutoCam>().SetTarget(player1.transform);
        player1.GetComponent<StandardCharacterController>()._playerAssign = "J1";
		player1.GetComponent<StandardCharacterController>().camAssign = 1;


        character2 = Resources.Load("Characters/" + (CharacterSelect.player2Character ?? "Tora"));
        GameObject player2 = (GameObject) Instantiate(character2, player2Spawn.position, player2Spawn.rotation);

        player2.tag = "Player2";
        player2Camera.GetComponent<AutoCam>().SetTarget(player2.transform);
        player2.GetComponent<StandardCharacterController>()._playerAssign = "J2";
		player2.GetComponent<StandardCharacterController> ().camAssign = 2;


    }

    void Update()
    {

    }
}
