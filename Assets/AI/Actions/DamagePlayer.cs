using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;
using RAIN.Perception.Sensors;
using RAIN.Entities.Aspects;

[RAINAction]
public class DamagePlayer : RAINAction
{
    public VisualSensor playerSensor;
    public GameObject playerObject;

    public override void Start(RAIN.Core.AI ai)
    {
        playerSensor = ai.Senses.GetSensor("Melee Sensor") as VisualSensor;
        base.Start(ai);

    }

    public override ActionResult Execute(RAIN.Core.AI ai)
    {
        if(playerSensor.Matches.Count > 0)
        {
            RAINAspect aspect = playerSensor.Matches[0];
            playerObject = aspect.Entity.Form.gameObject;
            if(playerObject.tag == "Player1" || playerObject.tag == "Player2")
            {
                playerObject.GetComponent<CharacterStats>().TakeDamage(10);
            }
        }
        return ActionResult.SUCCESS;
    }

    public override void Stop(RAIN.Core.AI ai)
    {
        base.Stop(ai);
    }
}