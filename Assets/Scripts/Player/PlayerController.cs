using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	[SerializeField]
	protected Animator _animator;
	public Animator Animator {
		get { return _animator; }
		protected set { _animator = value; }
	}
	
	float rotationSpeed = 30;
	Vector3 inputVec;
	bool isMoving;
	bool isStunned;

	[SerializeField]
	private string PlayerAssign = "K1";
	
	void Update()
	{
		//Get input from controls
		float x = Input.GetAxis(PlayerAssign + "_Horizontal");
		float z = Input.GetAxis(PlayerAssign + "_Vertical");
		inputVec = new Vector3(x, 0, z);
		
		//Apply inputs to animator
		_animator.SetFloat("Input X", x);
		_animator.SetFloat("Input Z", z);
		
		
		if (x != 0 || z != 0 )  //if there is some input
		{
			//set that character is moving
			_animator.SetBool("Moving", true);
			_animator.SetBool("Running", true);
			isMoving = true;
		}
		else
		{
			//character is not moving
			_animator.SetBool("Moving", false);
			_animator.SetBool("Running", false);	
			isMoving = false;
		}
		
		if (Input.GetButtonDown(PlayerAssign + "_Fire1"))
		{
			_animator.SetTrigger("Attack1Trigger");
		}
		if (Input.GetButtonDown(PlayerAssign + "_Fire2")){
			_animator.SetTrigger("Attack2Trigger");
		}
		if(Input.GetButtonDown(PlayerAssign + "_Fire3")){
			_animator.SetTrigger("Attack3Trigger");
		}
		if(isMoving && Input.GetButtonDown(PlayerAssign + "_Jump")){
			_animator.SetTrigger("JumpTrigger");
		}
		UpdateMovement();  //update character position and facing
	}
	
	/*public IEnumerator COStunPause(float pauseTime)
	{
		_animator.SetBool("IsStunned", true);	
		yield return new WaitForSeconds(pauseTime);
		_animator.SetBool("IsStunned", false);
	}*/
	
	void RotateTowardsMovementDir()  //face character along input direction
	{
		if (inputVec != Vector3.zero)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(inputVec), Time.deltaTime * rotationSpeed);
		}
	}
	
	float UpdateMovement()
	{
		Vector3 motion = inputVec;  //get movement input from controls
		
		//reduce input for diagonal movement
		motion *= (Mathf.Abs(inputVec.x) == 1 && Mathf.Abs(inputVec.z) == 1)?.7f:1;
		
		RotateTowardsMovementDir();  //if not strafing, face character along input direction
		
		return inputVec.magnitude;  //return a movement value for the animator, not currently used
	}

	void OnCollisionEnter (Collision collision)
	{
		
		if (collision.collider.gameObject.tag == "weapon") {
			_animator.Play("Hit Reaction");
			
		}
	}

}