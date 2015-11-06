using UnityEngine;
using System.Collections;

public class HealthModifier : MonoBehaviour 
{

	float health = 100;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Alpha7))
		{
			health = 0;
			print("test");
		}
	}

//	public float setHealth()
//	{
//
//
//	}
}
