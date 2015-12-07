using UnityEngine;
using System.Collections;

public class Chase : MonoBehaviour {
    public string tag;
    public float speed;

    private Vector3 direction;

    GameObject target;

	void Start () {
        target = GameObject.FindGameObjectWithTag(tag);
	}
	
	void Update () {
        direction = target.transform.position - transform.position;
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
	}
}
