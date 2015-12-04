using UnityEngine;
using System.Collections;

public class RagdollController : MonoBehaviour {

	[SerializeField]
	private Collider[] cols;

	[SerializeField]
	private Rigidbody[] rigids;

	[SerializeField]
	private CharacterJoint[] CharJoints; 

	private Animator anim;
	bool goRagdoll;
	[SerializeField]
	Rigidbody mainRagdoll;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		cols = GetComponentsInChildren<Collider>();
		rigids = GetComponentsInChildren<Rigidbody>();
		mainRagdoll = GetComponent<Rigidbody>();
		CharJoints = GetComponentsInChildren<CharacterJoint>();

		foreach(Collider col in cols)
		{
			if(col.gameObject.layer == 9)
			{
				col.isTrigger = true;
			}
		}

		foreach(Rigidbody rigid in rigids)
		{
			if(rigid.gameObject.layer == 9)
			{
				rigid.isKinematic = true;

			}
		}

		foreach(CharacterJoint CharJoint in CharJoints)
		{
			CharJoint.enableProjection = true;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void triggerRagdoll()
	{

		if(!goRagdoll)
		{

			foreach(Collider col in cols)
			{
				if(col.gameObject.layer == 9)
				{
					col.isTrigger = false;
				}
			}
			
			foreach(Rigidbody rigid in rigids)
			{
				if(rigid.gameObject.layer == 9)
				{
					rigid.isKinematic = false;
					rigid.velocity = mainRagdoll.velocity;

				}
			}

			goRagdoll = true;

			if(GetComponent<StandardCharacterController>())
			{
				StandardCharacterController standardCharacterController = GetComponent<StandardCharacterController>();
				standardCharacterController.enabled = false;
			}

			Collider chCol = GetComponent<Collider>();
			chCol.enabled = false;

			Rigidbody chRigid = GetComponent<Rigidbody>();
			chRigid.isKinematic = true;

			anim.enabled = false;
		}
	}
}
