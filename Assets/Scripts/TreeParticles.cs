using UnityEngine;
using System.Collections;

public class TreeParticles : MonoBehaviour {
    public GameObject snow;
    Vector3 trans;
    Object temp;
    void OnCollisionEnter(Collision col)
    {
        trans = transform.position;
        trans.y += 5;
        temp = Instantiate(snow, trans, Quaternion.identity);
        Destroy(temp, 5f);
    }
}
