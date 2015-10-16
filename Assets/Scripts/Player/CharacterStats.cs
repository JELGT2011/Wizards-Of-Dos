using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour 
{

	[SerializeField]
	private float health = 100;

	private float throwDamage = 0;
	
	RagdollController rdc;
	// Use this for initialization
	void Start () 
	{
		rdc = GetComponent<RagdollController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		TakeDamage(throwDamage);
		if(Input.GetKeyDown(KeyCode.Z))
		{
			health = 0;
		}

	}
	
	void TakeDamage(float damage)
	{
		health -= damage;
		if(health <= 0)
		{
			rdc.triggerRagdoll();
		}
	}
}
