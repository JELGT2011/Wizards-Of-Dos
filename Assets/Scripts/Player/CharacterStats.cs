using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour 
{

	[SerializeField]
	private float health = 100;
	
	RagdollController rdc;
	// Use this for initialization
	void Start () 
	{
		rdc = GetComponent<RagdollController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Z))
		{
			health = 0;
			print ("test");
		}

	}
	
	void TakeDamage(int damage){
		health -= damage;
		if(health <= 0)
		{
			rdc.triggerRagdoll();
		}
	}
}
