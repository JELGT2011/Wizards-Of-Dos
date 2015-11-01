using UnityEngine;
using System.Collections;

public class Fight : MonoBehaviour
{
	
	[SerializeField]
	protected Animator animator;
	private BoxCollider[] weaponColliders;
	private CapsuleCollider playerCollider;
	private Transform player;
	CharacterStats playerStats;
	readonly string[] Attacks = {"Attack1", "Attack2", "Attack3"};
	float timeBetweenAttacks = 1f;
	float timer;
	
	// Use this for initialization
	void Start()
	{
		player = GetComponent<Transform>();
		animator = GetComponent<Animator>();
		weaponColliders = GetComponentsInChildren<BoxCollider>();
		playerCollider = GetComponent<CapsuleCollider>();
		playerStats = GetComponent<CharacterStats>();
		foreach(BoxCollider weaponCollider in weaponColliders)
		{
			Physics.IgnoreCollision(weaponCollider, playerCollider);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		timer += Time.deltaTime;
	}
	
	void FixedUpdate ()
	{
		
	}
	
	void OnCollisionEnter (Collision collision)
	{
		GameObject collidingObject = collision.collider.gameObject;
		string colliderTag = collidingObject.tag;
		
		// Check to see if the colliding object is a weapon
		if(colliderTag == "Weapon"){
			Transform enemy = collidingObject.transform.root;
			Animator enemyAnimator = enemy.GetComponent<Animator>();
			AnimatorStateInfo enemyAnimationState = enemyAnimator.GetCurrentAnimatorStateInfo(0);
			// Prevent multiple damage occurences per attack
			if(timer >= timeBetweenAttacks){
				bool isEnemyAttack = false;
				float damage = 0;
				foreach(string Attack in Attacks){
					if(enemyAnimationState.IsName(Attack)){
						isEnemyAttack = true;
						damage = playerStats.GetAttackDamage(Attack);
					}
				}
				// If it is, check the animation state of the enemy to see if he is attacking or not			
				if(isEnemyAttack){
					player.LookAt(enemy.position);
					animator.Play ("HitReaction");
					playerStats.TakeDamage(damage);
					timer = 0f;
				}
			}
		}
	}
}