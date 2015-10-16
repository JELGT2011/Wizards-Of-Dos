using UnityEngine;
using System.Collections;

public class TreeParticles : MonoBehaviour {
    public GameObject snow;


    void OnCollisionEnter(Collision col)
    {
        Instantiate(snow, transform.position, Quaternion.identity);
    }
}
