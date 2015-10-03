using UnityEngine;
using System.Collections;

public class NinjaControlScript : MonoBehaviour {
	
	public Animator animator;
	
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
		animator.SetFloat("Input X", x);
		animator.SetFloat("Input Z", z);
		
		
		if (x != 0 || z != 0 )  //if there is some input
		{
			//set that character is moving
			animator.SetBool("Moving", true);
			isMoving = true;
			animator.SetBool("Running", true);
		}
		else
		{
			//character is not moving
			animator.SetBool("Moving", false);
			animator.SetBool("Running", false);	
			isMoving = false;
		}
		
		if (Input.GetButtonDown(PlayerAssign + "_Fire1") && !animator.GetBool("IsStunned"))
		{
			animator.SetTrigger("Attack1Trigger");
			StartCoroutine (COStunPause(.6f));
		}
		if (Input.GetButtonDown(PlayerAssign + "_Fire2") && !animator.GetBool("IsStunned")){
			animator.SetTrigger("Attack2Trigger");
			StartCoroutine (COStunPause(.9f)); 
		}
		if(Input.GetButtonDown(PlayerAssign + "_Fire3") && !animator.GetBool("IsStunned")){
			animator.SetTrigger("Attack3Trigger");
			StartCoroutine (COStunPause(1.1f));
		}
		if(isMoving && Input.GetButtonDown(PlayerAssign + "_Jump") && !animator.GetBool("IsStunned")){
			animator.SetTrigger("JumpTrigger");
			StartCoroutine (COStunPause(1.7f));
		}
		UpdateMovement();  //update character position and facing
	}
	
	public IEnumerator COStunPause(float pauseTime)
	{
		animator.SetBool("IsStunned", true);	
		yield return new WaitForSeconds(pauseTime);
		animator.SetBool("IsStunned", false);
	}
	
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

}