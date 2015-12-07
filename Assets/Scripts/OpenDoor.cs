using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	Rigidbody DRB;

	[SerializeField]
	private float direction = 1;
	[SerializeField]
	private float forcePower = 1150;
	private float distancePlayer1 = 0;
	private float distancePlayer2 = 0;

	GameObject player1;
	GameObject player2;
	

	// Use this for initialization
	void Start () 
	{
		DRB = GetComponent<Rigidbody>();
		player1 = GameObject.FindGameObjectWithTag("Player1Char");
		player2 = GameObject.FindGameObjectWithTag("Player2Char");
		
	}
	
	// Update is called once per frame
	void Update () 
	{

		triggerDoor();

	}

	void triggerDoor()
	{
		if(player1 == null){
			player1 = GameObject.FindGameObjectWithTag("Player1Char");
		}
		if(player2 == null){
			player2 = GameObject.FindGameObjectWithTag("Player2Char");
		}
		distancePlayer1 = Vector3.Distance(player1.transform.position, this.transform.position);
		distancePlayer1 = Vector3.Distance(player2.transform.position, this.transform.position);
		if(Input.GetKeyDown(KeyCode.O) && (distancePlayer1 <= 3 || distancePlayer1 <= 3))
		{
			DRB.AddForce(transform.forward * forcePower * direction, ForceMode.Impulse);
			print("open");
		}
	}
}
