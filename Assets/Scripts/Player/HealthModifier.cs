using UnityEngine;
using System.Collections;
using RAIN.Core;


public class HealthModifier : MonoBehaviour 
{
	float health = 100;

	AIRig NinjaRig;

	// Use this for initialization
	void Start () 
	{
		NinjaRig = gameObject.GetComponentInChildren<AIRig>();
		NinjaRig.AI.WorkingMemory.SetItem<float>("AI_Health", health);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Alpha7))
		{
			NinjaRig.AI.WorkingMemory.SetItem<float>("AI_Health", health - 50);
		}

		if(Input.GetKeyDown(KeyCode.Alpha8))
		{
			NinjaRig.AI.WorkingMemory.SetItem<float>("AI_Health", health - 100);
		}
	}

//	public float setHealth()
//	{
//
//
//	}
}
