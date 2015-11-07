using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class Ragdoll : RAINAction
{
	RagdollController rdc; 
	HealthModifier health;
	
	public Ragdoll()
	{
		actionName = "Ragdoll";
	}

    public override void Start(RAIN.Core.AI ai)
    {
		rdc = ai.Body.GetComponent<RagdollController> ();
		health = ai.Body.GetComponent<HealthModifier>();

        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {


		if(Input.GetKeyDown(KeyCode.Alpha7))
		{
			Debug.Log ("Test");
		}

		if (ai.WorkingMemory.GetItem<float>("AI_Health") <= 0) 
		{
			rdc.triggerRagdoll();
		}
		ai.WorkingMemory.SetItem("AI_Health", 0);

        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}