using UnityEngine;
using System.Collections;

public class StandardCharacterController : MonoBehaviour {

	[SerializeField]
	protected Animator _animator;
	public Animator Animator
	{
		get { return _animator; }
		protected set { _animator = value; }
	}

	CapsuleCollider bodyCol;
	GameObject playerCam;

	float rotationSpeed = 30;

	private Vector3 inputVec;
	bool inLocomotionState;

	protected bool _isMoving;
	public bool IsMoving
	{
		get { return _isMoving; }
	}

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
		float x = Input.GetAxis(_playerAssign + "_Horizontal");
		float z = Input.GetAxis(_playerAssign + "_Vertical");
		inputVec = new Vector3(x, 0, z);
		inputVec = playerCam.transform.TransformDirection(inputVec);
		inputVec.y = 0;

		//Apply inputs to animator
		_animator.SetFloat("Input X", x);
		_animator.SetFloat("Input Z", z);

		if (x != 0 || z != 0 )  //if there is some input
		{
			//set that character is moving
			_animator.SetBool("Moving", true);
			_isMoving = true;
			if(Mathf.Abs(x) >= 0.2 || Mathf.Abs(z) >= 0.2)
			{
				_animator.SetBool("Running", true);
			}
		}
		else
		{
			//character is not moving
			_animator.SetBool("Moving", false);
			_animator.SetBool("Running", false);
			_isMoving = false;
		}

		inLocomotionState = _animator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion");

		// Prevent trigger buffering in other states
		if(inLocomotionState){
			if (Input.GetButtonDown(_playerAssign + "_Fire1"))
			{
				_animator.SetTrigger("Attack1Trigger");
			}

			if (Input.GetButtonDown(_playerAssign + "_Fire2"))
			{
				_animator.SetTrigger("Attack2Trigger");
			}

			if(Input.GetButtonDown(_playerAssign + "_Fire3"))
			{
				_animator.SetTrigger("Attack3Trigger");
			}

			if(_isMoving && Input.GetButtonDown(_playerAssign + "_Jump"))
			{
				_animator.SetTrigger("JumpTrigger");
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
