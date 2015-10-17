using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {

	Rigidbody DRB;

	[SerializeField]
	private float direction = 1;
	[SerializeField]
	private float forcePower = 1150;
	private float distance = 0;

	GameObject player;

	// Use this for initialization
	void Start () 
	{
		DRB = GetComponent<Rigidbody>();
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{

		triggerDoor();

	}

	void triggerDoor()
	{
		distance = Vector3.Distance(player.transform.position,this.transform.position);


		if(Input.GetKeyDown(KeyCode.O) && distance <= 3)
		{
			DRB.AddForce(transform.forward * forcePower * direction, ForceMode.Impulse);
			print("open");
		}
	}
}
