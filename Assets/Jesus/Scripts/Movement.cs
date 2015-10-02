using UnityEngine;
using System.Collections;
//requrired components
[RequireComponent(typeof (Animator))]
[RequireComponent(typeof (CapsuleCollider))]
[RequireComponent(typeof (Rigidbody))]
public class Movement : MonoBehaviour {

	//public variables
	public float animSpeed = 1.5f;				// a public setting for overall animator animation speed

	//private variables
	private Animator anim;							// a reference to the animator on the character
	private AnimatorStateInfo currentBaseState;			// a reference to the current state of the animator, used for base layer

	bool block;

	//states stored as ints
	static int standingState = Animator.StringToHash("Base Layer.Standing");
	static int turnRState = Animator.StringToHash("Base Layer.TurnRight");
	static int turnLState = Animator.StringToHash("Base Layer.TurnLeft");
	static int deathState = Animator.StringToHash("Base Layer.Death");
	static int locoState = Animator.StringToHash("Base Layer.Loco");
	static int walkBackState = Animator.StringToHash("Base Layer.WalkBack");
	static int jumpAttState = Animator.StringToHash("Base Layer.JumpAttack");
	static int jumpState = Animator.StringToHash("Base Layer.Jump");
	static int att1State = Animator.StringToHash("Base Layer.Attack1");
	static int att2State = Animator.StringToHash("Base Layer.Attack2");
	static int att3State = Animator.StringToHash("Base Layer.Attack3");

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();		
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//update called at set interval
	void FixedUpdate() 
	{
		float h = Input.GetAxis("Horizontal");				// setup h variable as our horizontal input axis
		float v = Input.GetAxis("Vertical");				// setup v variables as our vertical input axis

		anim.SetFloat("Speed", v);							// set our animator's float parameter 'Speed' equal to the vertical input axis				
		anim.SetFloat("Direction", h); 						// set our animator's float parameter 'Direction' equal to the horizontal input axis		
		anim.speed = animSpeed;								// set the speed of our animator to the public variable 'animSpeed'
		currentBaseState = anim.GetCurrentAnimatorStateInfo(0);	// set our currentState variable to the current state of the Base Layer (0) of animation


		//idle/standing
		if (currentBaseState.nameHash == standingState) {
			if (Input.GetButtonUp ("Fire1")) {
				anim.SetBool ("Attack1", true);
			}
		} else if (currentBaseState.nameHash == locoState) {
			if (Input.GetButtonUp ("Fire3")) {
				print ("FIRE!");
				anim.SetBool ("JumpAttack", true);
			}
			if (Input.GetButtonUp ("Fire1")) {
				anim.SetBool ("Attack1", true);
			}
		} else if (currentBaseState.nameHash == walkBackState) {
			if (Input.GetButtonUp ("Fire1")) {
				anim.SetBool ("Attack1", true);
			}
		} else if (currentBaseState.nameHash == jumpState) {		//reset jump
			anim.SetBool ("Jump", false);
		} else if (currentBaseState.nameHash == jumpAttState) {		//reset jump attack
			anim.SetBool ("JumpAttack", false);
		} 
		if (currentBaseState.nameHash == att1State) {		//Attack state 1
			anim.SetBool ("Attack1", false);
			if (Input.GetButtonUp ("Fire1")) {
				anim.SetBool ("Attack2", true); 
			}
		} else if (currentBaseState.nameHash == att2State) {		//Attack state 2
			anim.SetBool ("Attack2", false);
			if (Input.GetButtonUp ("Fire1")) {
				anim.SetBool ("Attack3", true); 
			}
		} else if (currentBaseState.nameHash == att3State) {		//Attack state 3
			anim.SetBool ("Attack3", false);
		}
		//block
		if (Input.GetButtonUp ("Fire2")) {
			block = !block;
			anim.SetBool ("Block", block); 
		}

		//Jump
		if (Input.GetButtonUp ("Jump")) {
			anim.SetBool ("Jump", true);
		}




	}
}
