//robert

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NinjaHealth : MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;
	public AudioClip deathClip;
	NinjaControlScript playerMovement;
	Animator anim;
	AudioSource ninjaAudio;
	bool isDead;
	bool damaged;
	
	
	void Awake ()
	{
		anim = GetComponent <Animator> ();
		ninjaAudio = GetComponent <AudioSource> ();
		currentHealth = startingHealth;
	}
	
	
	void Update ()
	{
		damaged = false;
	}
	
	
	public void TakeDamage (int amount)
	{
		damaged = true;
		
		currentHealth -= amount;
				
		ninjaAudio.Play ();
		
		if(currentHealth <= 0 && !isDead)
		{
			Death ();
		}
	}
	
	
	void Death ()
	{
		isDead = true;		
		anim.SetTrigger ("Die");
		ninjaAudio.clip = deathClip;
		ninjaAudio.Play ();
		playerMovement.enabled = false;
	}
	
}
