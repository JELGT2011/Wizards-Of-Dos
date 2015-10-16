using UnityEngine;
using System.Collections;

public class NinjaControlScript : MonoBehaviour {
	
	public Animator animator;
	public AudioSource audioSource;
	AudioClip sandStep;
	AudioClip rockHit;
	AudioClip cactusHit;
	float rotationSpeed = 30;
	Vector3 inputVec;
	bool isMoving;
	bool isStunned;
	string floorTag;
	[SerializeField]
	private string PlayerAssign = "K1";
	void Awake(){
		audioSource = GetComponent<AudioSource>();
		animator = GetComponent<Animator>();
		sandStep = (AudioClip)Resources.Load("Audio/sand_step");
		rockHit = (AudioClip)Resources.Load("Audio/rock_hit");
		cactusHit = (AudioClip)Resources.Load("Audio/cactus_hit");
	}
	void Update()
	{
		RaycastHit hit;
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
			if(Mathf.Abs(x) >= 0.2 || Mathf.Abs(z) >= 0.2){
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
		if(animator.GetBool ("Running") && animator.GetBool ("IsStunned") == false){
			if (Physics.Raycast(transform.position, Vector3.down, out hit))
			{
				//This is the colliders tag
				floorTag = hit.collider.tag;
			}
			
			//Then you use the floorTag to choose the type of footstep
			if (floorTag == "Sand")
			{
				audioSource.clip = sandStep;
				audioSource.pitch = 2.25f; //Increase the pitch to increase speed of audio clip
				if(audioSource.isPlaying == false)
					audioSource.Play();
			}
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
	
	void OnCollisionEnter (Collision collision){
		if(collision.gameObject.tag == "Rock"){
			animator.Play("Hit Reaction");
			StartCoroutine (COStunPause(1.2f));
			audioSource.clip = rockHit;
			if(audioSource.isPlaying == false)
				audioSource.Play();
		}
		if(collision.gameObject.tag == "Cactus"){
			animator.Play("Hit Reaction");
			StartCoroutine (COStunPause(1.2f));
			audioSource.clip = cactusHit;
			if(audioSource.isPlaying == false)
				audioSource.Play();
		}
	}

}