using UnityEngine;
using System.Collections;

public class SpiderController : MonoBehaviour {
    public GameObject baneling;
    public int banelingNum;

    Object[] clone = new Object[10];
    Vector3 force, position;

    void OnTriggerEnter (Collider other)
    {
        if( other.tag == "Player1"| other.tag == "Player2")
        {
            Destroy(gameObject);
            for (int i = 0; i < banelingNum; i++)
            {
                force = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
                position = gameObject.transform.position + force;
                Debug.Log(force);

                clone[i] = Instantiate(baneling, position, Quaternion.identity);
                //clone[i].GetComponent<Rigidbody>().AddForce(force);
            }
        }
    }
}
