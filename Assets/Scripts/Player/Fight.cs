using UnityEngine;
using System.Collections;

public class Fight : MonoBehaviour
{

	[SerializeField]
	protected Animator _animator;
	public Animator Animator
	{
		get { return _animator; }
		protected set { _animator = value; }
	}


	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	void FixedUpdate ()
	{

	}

	void OnCollisionEnter (Collision collision)
	{
		if (collision.collider.gameObject.tag == "weapon") {
			_animator.Play ("Hit Reaction");
		}
	}
}
