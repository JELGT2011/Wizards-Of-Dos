using UnityEngine;
using System.Collections;

public class RagdollController : MonoBehaviour {

	[SerializeField]
	private Collider[] cols;

	[SerializeField]
	private Rigidbody[] rigids;

	private Animator anim;
	bool goRagdoll;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		cols = GetComponentsInChildren<Collider>();
		rigids = GetComponentsInChildren<Rigidbody>();

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
				}
			}

			goRagdoll = true;

//			MainControllerScript MCS = GetComponent<MainControllerScript>();
//			MCS.enabled = false;

			Collider chCol = GetComponent<Collider>();
			chCol.enabled = false;

			Rigidbody chRigid = GetComponent<Rigidbody>();
			chRigid.isKinematic = true;

			anim.enabled = false;
		}
	}
}
