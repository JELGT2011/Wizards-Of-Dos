using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterStats : MonoBehaviour 
{

	[SerializeField]
	private float health = 100;
	private int attack1Damage = 20;
	int attack2Damage = 15;
	int attack3Damage = 30;
	Dictionary<string, int> attackDamage;
	
	RagdollController rdc;
	// Use this for initialization
	void Start () 
	{
		attackDamage = new Dictionary<string, int>();
		attackDamage.Add("Attack1", attack1Damage);
		attackDamage.Add("Attack2", attack2Damage);
		attackDamage.Add("Attack3", attack3Damage);
		rdc = GetComponent<RagdollController>();
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
	
	public void TakeDamage(float damage)
	{
		health -= damage;
		if(health <= 0)
		{
			rdc.triggerRagdoll();
		}
	}
	
	//Return the damage from an attack given its name
	public int GetAttackDamage(string attack){
		int damage;
		if(attackDamage.TryGetValue(attack, out damage)){
			return damage;
		}
		else{
			return 0;
		}
	}
	public float GetHealth(){
		return health;
	}
}
