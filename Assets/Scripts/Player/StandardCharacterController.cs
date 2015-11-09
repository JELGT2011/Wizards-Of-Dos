using UnityEngine;
using System.Collections;

public class StandardCharacterController : MonoBehaviour {

	public Animator animator;

	CapsuleCollider bodyCol;
	GameObject playerCam;
	
	float rotationSpeed = 30;

	private Vector3 inputVec;
	bool inLocomotionState;
	public bool isMoving;
	bool isStunned;
	bool isJumpTrigger;
	readonly string locomotion = "Locomotion";
	

	[SerializeField] private string PlayerAssign = "K1";
	[SerializeField] [Range (1,2)] private int camAssign = 1;

	void Start()
	{
		playerCam = GameObject.FindGameObjectWithTag("PlayerCam" + camAssign);
		animator = GetComponent<Animator>();	
		bodyCol = GetComponent<CapsuleCollider>();
	}

	void Update()
	{
		characterMove();
		//update character position and facing
		UpdateMovement();  
//		//Change Collider Height
//		if (!animator.IsInTransition (0)) 
//		{
//			bodyCol.height = animator.GetFloat("ColliderHeight");
//		}
		
	}
	
	
	void RotateTowardsMovementDir()  //face character along input direction
	{
		if (inputVec != Vector3.zero)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(inputVec), Time.deltaTime * rotationSpeed);
		}
	}

	void characterMove()
	{
		//Get input from controls
		float x = Input.GetAxis(PlayerAssign + "_Horizontal");
		float z = Input.GetAxis(PlayerAssign + "_Vertical");
		inputVec = new Vector3(x, 0, z);
		inputVec = playerCam.transform.TransformDirection(inputVec);
		inputVec.y = 0;
		
		//Apply inputs to animator
		animator.SetFloat("Input X", x);
		animator.SetFloat("Input Z", z);

		if (x != 0 || z != 0 )  //if there is some input
		{
			//set that character is moving
			animator.SetBool("Moving", true);
			isMoving = true;
			if(Mathf.Abs(x) >= 0.2 || Mathf.Abs(z) >= 0.2)
			{
				animator.SetBool("Running", true);
			}
		}
		else
		{
			//character is not moving
			animator.SetBool("Moving", false);
			animator.SetBool("Running", false);	
			isMoving = false;
		}
		
		inLocomotionState = animator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion");
		Debug.Log (inLocomotionState);
		// Prevent trigger buffering in other states
		if(inLocomotionState){
			if (Input.GetButtonDown(PlayerAssign + "_Fire1"))
			{
				animator.SetTrigger("Attack1Trigger");
			}
	
			if (Input.GetButtonDown(PlayerAssign + "_Fire2"))
			{
				animator.SetTrigger("Attack2Trigger");
			}
	
			if(Input.GetButtonDown(PlayerAssign + "_Fire3"))
			{
				animator.SetTrigger("Attack3Trigger");
			}
	
			if(isMoving && Input.GetButtonDown(PlayerAssign + "_Jump"))
			{
				animator.SetTrigger("JumpTrigger");
			}
		}
	}

	void UpdateMovement()
	{
		Vector3 motion = inputVec;  //get movement input from controls
		
		//reduce input for diagonal movement
		motion *= (Mathf.Abs(inputVec.x) == 1 && Mathf.Abs(inputVec.z) == 1)?.7f:1;
		if(inLocomotionState){
		RotateTowardsMovementDir();  //if not strafing, face character along input direction
		}
		
//		return inputVec.magnitude;  //return a movement value for the animator, not currently used
	}
	

}
