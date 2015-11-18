using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
	[SerializeField]
	protected ParticleSystem[] _particleSystem;
	public ParticleSystem[] ParticleSystem
	{
		get { return _particleSystem; }
		set { _particleSystem = value; }
	}

	void Start()
	{
		
	}

	void Update()
	{
	
	}
}
