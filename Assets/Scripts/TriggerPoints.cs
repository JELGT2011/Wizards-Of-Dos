using UnityEngine;
using System.Collections;

public class TriggerPoints : MonoBehaviour {
	public static bool isDead = false;
	
	public int bonus = 10;
	
	private CharacterStats playerHealth1;
	private CharacterStats playerHealth2;

	GameObject P1;
	GameObject P2;



	// Use this for initialization
	void Start () {
		P1 = GameObject.FindGameObjectWithTag("Player1");
		P2 = GameObject.FindGameObjectWithTag ("Player2");
		playerHealth1 = P1.GetComponent<CharacterStats> ();
		playerHealth2 = P2.GetComponent<CharacterStats> ();
	}


	void OnTriggerEnter(Collider p)
	{
		if (p.gameObject == P1) 
		{
			playerHealth1.AddHealth(bonus);
		}else if (p.gameObject == P2)
		{
			playerHealth2.AddHealth(bonus);
		}
		Destroy (gameObject, 0f);
	}
}
