using UnityEngine;
using System.Collections;

public class explode : MonoBehaviour {
    public GameObject explosion;

    Object blowUp;
    Vector3 location;


    void OnTriggerEnter (Collider other)
    {
        if(other.tag == "Player1"|other.tag =="Player2")
        {
            location = gameObject.transform.position;
            Debug.Log("Object Entered the trigger");
            blowUp = Instantiate(explosion, location, Quaternion.identity);
            Destroy(gameObject);
            Destroy(blowUp, 4f);
        }
        
    }
}
