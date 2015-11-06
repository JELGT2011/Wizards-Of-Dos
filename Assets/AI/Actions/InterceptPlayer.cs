using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Action;
using RAIN.Core;

[RAINAction]
public class InterceptPlayer : RAINAction
{
	protected GameObject _targetPredictionObject = GameObject.Find("PlayerPrediction") as GameObject;

	protected RAIN.Perception.Sensors.VisualSensor _farSensor;

	protected Vector2 _target;

	protected Transform _selfTransform;
	protected Vector2 _self;
	
	protected Vector2 _targetPrevPosition;
	protected Vector2 _selfPrevPosition;
	
	protected Vector2 _targetVelocity;
	protected Vector2 _selfVelocity;
	
	protected Vector2 _positionDifference;
	protected Vector2 _velocityDifference;
	protected float _timeToClose;
	protected Vector2 _targetPrediction2D;
	protected Vector3 _targetPrediction;

	protected float EXECUTE_FREQUENCY = 1f;
	protected float _lastExecute = Time.time;

	public override void Start(RAIN.Core.AI ai)
	{
		base.Start(ai);
		_farSensor = ai.Senses.GetSensor("FarSensor") as RAIN.Perception.Sensors.VisualSensor;
		_selfTransform = ai.Body.GetComponent<Transform>();
	}
	
	public override ActionResult Execute(RAIN.Core.AI ai)
	{
		if (_lastExecute + EXECUTE_FREQUENCY < Time.time)
		{
			_lastExecute = Time.time;

			if (_farSensor.Matches.Count != 0)
			{
				_target = new Vector2(_farSensor.Matches[0].Position.x, _farSensor.Matches[0].Position.z);
			}
			_self = new Vector2(_selfTransform.position.x, _selfTransform.position.z);
			
			Debug.Log("_target = " + _target);
			Debug.Log("_self = " + _self);

			_targetVelocity = (_target - _targetPrevPosition) / EXECUTE_FREQUENCY;
			_selfVelocity = (_self - _selfPrevPosition) / EXECUTE_FREQUENCY;
			
			Debug.Log("_targetVelocity = " + _targetVelocity);
			Debug.Log("_selfVelocity = " + _selfVelocity);
			
			_positionDifference = _target - _self;
			_velocityDifference = _targetVelocity - _selfVelocity;

			if (_velocityDifference.magnitude != 0f && !_targetVelocity.Equals(Vector2.zero))
			{
				_timeToClose = _positionDifference.magnitude / _velocityDifference.magnitude;
				_targetPrediction2D = _target + (_targetVelocity * _timeToClose);
				_targetPrediction = new Vector3(_targetPrediction2D.x, 0f, _targetPrediction2D.y);
			}
			else
			{
				_targetPrediction = new Vector3(_target.x, 0f, _target.y);
			}
			
			Debug.Log("_targetPrediction = " + _targetPrediction);
			_targetPredictionObject.transform.position = _targetPrediction;
			
			_targetPrevPosition = _target;
			_selfPrevPosition = _self;

		}

		return ActionResult.SUCCESS;
	}
	
	public override void Stop(RAIN.Core.AI ai)
	{
		base.Stop(ai);
	}
}