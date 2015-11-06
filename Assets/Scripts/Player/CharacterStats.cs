using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class CharacterStats : MonoBehaviour 
{
	
	[SerializeField]
	public int startingHealth = 100;                            // The amount of health the player starts the game with.
	public int currentHealth;                                   // The current health the player has.
	public Slider healthSlider;                                 // Reference to the UI's health bar.
	int attack1Damage = 20;
	int attack2Damage = 15;
	int attack3Damage = 30;
	private Animator animator;
	Dictionary<string, int> attackDamage;
	
	RagdollController rdc;
	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		attackDamage = new Dictionary<string, int>();
		attackDamage.Add("Attack1", attack1Damage);
		attackDamage.Add("Attack2", attack2Damage);
		attackDamage.Add("Attack3", attack3Damage);
		rdc = GetComponent<RagdollController>();
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Z))
		{
			rdc.triggerRagdoll();
			animator.SetTrigger("DeathTrigger");
		}
	}
	
	public void TakeDamage(int damage)
	{
		currentHealth -= damage;
		healthSlider.value = currentHealth;
		if(currentHealth <= 0)
		{
			rdc.triggerRagdoll();
			animator.SetTrigger("DeathTrigger");
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
		return currentHealth;
	}
}
