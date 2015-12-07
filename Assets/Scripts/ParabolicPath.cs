using UnityEngine;
using System.Collections;

public class ParabolicPath : MonoBehaviour {
    public Transform myTarget;

    Vector3 dir;
    float h, dist, vel;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = BallisticVel(myTarget);
    }

    Vector3 BallisticVel(Transform target)
    {
        dir = target.position - transform.position; // get target direction
        h = dir.y;  // get height difference
        dir.y = 0;  // retain only the horizontal direction
        dist = dir.magnitude;  // get horizontal distance
        dir.y = dist;  // set elevation to 45 degrees
        dist += h;  // correct for different heights
        vel = Mathf.Sqrt(dist * Physics.gravity.magnitude);
        return vel * dir.normalized;  // returns Vector3 velocity
    }
}
