using UnityEngine;
using System.Collections;
using RAIN.Core;


public class HealthModifier : MonoBehaviour 
{

	AIRig NinjaRig;

	// Use this for initialization
	void Start () 
	{
		NinjaRig = gameObject.GetComponentInChildren<AIRig>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Alpha7))
		{
			NinjaRig.AI.WorkingMemory.SetItem<float>("AI_Health", 50);
		}

		if(Input.GetKeyDown(KeyCode.Alpha8))
		{
			NinjaRig.AI.WorkingMemory.SetItem<float>("AI_Health", 100);
		}

		if(Input.GetKeyDown(KeyCode.Alpha9))
		{
			NinjaRig.AI.WorkingMemory.SetItem<float>("AI_Health", 0);
		}
	}
}
