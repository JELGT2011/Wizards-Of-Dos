using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour 
{

	[SerializeField]
	private float health = 100;
	
	RagdollController rdc;
	// Use this for initialization
	void Start () 
	{
		rdc = GetComponent<RagdollController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(health <= 0)
		{
			rdc.triggerRagdoll();
		}

		if(Input.GetKeyDown(KeyCode.Z))
		{
			health = 0;
		}

	}
}
