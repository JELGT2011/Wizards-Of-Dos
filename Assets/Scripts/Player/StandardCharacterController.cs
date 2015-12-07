using UnityEngine;
using System.Collections;

public class StandardCharacterController : MonoBehaviour
{

    [SerializeField]
    public Animator _animator;
   

	Rigidbody rigid;

    
    GameObject playerCam;

	[SerializeField] float MovementSpeed = 1f;
	[SerializeField] float JumpStrength = 8f;
	[SerializeField] float GravityStrength = 2f;
	[SerializeField] float GroundCheckDistance = 0.23f;
	float origGroundCheckDis;
	bool isGrounded;
	bool Jump;
	Vector3 GroundNormal;




    float rotationSpeed = 30;

    private Vector3 inputVec;
    bool inLocomotionState;
	bool inJump;

    protected bool _isMoving;
    public bool IsMoving
    {
        get { return _isMoving; }
    }

    bool isStunned;
    bool isJumpTrigger;

    readonly string locomotion = "Locomotion";

    [SerializeField]
    public string _playerAssign = "K1";



    [SerializeField]
    [Range(1, 2)]
    public int camAssign = 1;

    void Start()
    {
        playerCam = GameObject.FindGameObjectWithTag("PlayerCam" + camAssign);
		inLocomotionState = _animator.GetCurrentAnimatorStateInfo(0).IsName("Locomotion");
		inJump = _animator.GetCurrentAnimatorStateInfo(0).IsName("Jumping");
		origGroundCheckDis = GroundCheckDistance;
		_animator = GetComponentInChildren<Animator>();
		rigid = GetComponent<Rigidbody>();
        

    }

    void Update()
    {
        characterMove();
        //update character position and facing
        UpdateMovement();
        
    }
	void FixedUpdate()
	{
		OverRideRootMotion();
		GroundCheck();
		if(isGrounded)
		{
			HandleJumping();
		}
		else
		{
			AirborneMovment();
		}
		Jump = false;
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
		_animator.SetBool("onGround", isGrounded);

		if (!isGrounded)
		{
			_animator.SetFloat("Jump", rigid.velocity.y);
		}

        if (x != 0 || z != 0)  //if there is some input
        {
            //set that character is moving
            _animator.SetBool("Moving", true);
            _isMoving = true;
            if (Mathf.Abs(x) >= 0.2 || Mathf.Abs(z) >= 0.2)
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




        // Prevent trigger buffering in other states
        if (inLocomotionState)
        {
            if (Input.GetButtonDown(_playerAssign + "_Fire1") && !inJump)
            {
                _animator.SetTrigger("Attack1Trigger");
            }

            if (Input.GetButtonDown(_playerAssign + "_Fire2"))
            {
                _animator.SetTrigger("Attack2Trigger");
            }

            if (Input.GetButtonDown(_playerAssign + "_Fire3"))
            {
                _animator.SetTrigger("Attack3Trigger");
                
            }

			if(!Jump)
			{
				Jump = Input.GetButtonDown(_playerAssign + "_Jump");
				//print (Jump);
			}
        }
    }

    void UpdateMovement()
    {
        Vector3 motion = inputVec;  //get movement input from controls

        //reduce input for diagonal movement
        motion *= (Mathf.Abs(inputVec.x) == 1 && Mathf.Abs(inputVec.z) == 1) ? .7f : 1;
        if (inLocomotionState)
        {
            RotateTowardsMovementDir();  //if not strafing, face character along input direction
        }

        
    }

	void HandleJumping()
	{
		if(Jump && inLocomotionState)
		{
			//Debug.Log("jumping");
			rigid.velocity = new Vector3(rigid.velocity.x, JumpStrength, rigid.velocity.z);
			isGrounded = false;
			_animator.applyRootMotion = false;
			GroundCheckDistance = 0.1f;
		}
	}

	void OverRideRootMotion()
	{
		if(isGrounded && Time.deltaTime > 0)
		{
			Vector3 v = (_animator.deltaPosition * MovementSpeed) / Time.deltaTime;
			v.y = rigid.velocity.y;
			rigid.velocity = v;
		}
	}

	void AirborneMovment()
	{

		rigid.AddForce(inputVec * 15, ForceMode.Force);
		Vector3 gravityFactor = (Physics.gravity * GravityStrength) - Physics.gravity;
		rigid.AddForce(gravityFactor);
		GroundCheckDistance = rigid.velocity.y < 0 ? origGroundCheckDis : 0.01f;
	}

	void GroundCheck()
	{
		RaycastHit hitInfo;
#if UNITY_EDITOR
		// helper to visualise the ground check ray in the scene view
		Debug.DrawLine(transform.position + (Vector3.up * 0.05f), transform.position + (Vector3.up * 0.05f) + (Vector3.down * GroundCheckDistance));
#endif
		// 0.1f is a small offset to start the ray from inside the character
		// it is also good to note that the transform position in the sample assets is at the base of the character
		if (Physics.Raycast(transform.position + (Vector3.up * 0.05f), Vector3.down, out hitInfo, GroundCheckDistance))
		{
			GroundNormal = hitInfo.normal;
			isGrounded = true;
			_animator.applyRootMotion = true;
		}
		else
		{
			isGrounded = false;
			GroundNormal = Vector3.up;
			_animator.applyRootMotion = false;
		}
	}
}
