using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class Ragdoll : RAINAction
{
	RagdollController rdc; 
	
	public Ragdoll()
	{
		actionName = "Ragdoll";
	}

    public override void Start(RAIN.Core.AI ai)
    {
		rdc = ai.Body.GetComponent<RagdollController> ();

		ai.WorkingMemory.SetItem("AI_Health", 50);

        base.Start(ai);
    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {


		if (ai.WorkingMemory.GetItem<float>("AI_Health") <= 0) 
		{
			rdc.triggerRagdoll();
		}


        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}