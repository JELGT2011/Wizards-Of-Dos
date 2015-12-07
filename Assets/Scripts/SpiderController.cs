using UnityEngine;
using System.Collections;

public class SpiderController : MonoBehaviour {
    public GameObject baneling;
    public int banelingNum;
    public int health;

    readonly string[] Attacks = { "Attack1", "Attack2", "Attack3" };
    string lastEnemy, targetEnemy;

    GameObject[] clone = new GameObject[5];
    Vector3 delta, position;
    CharacterStats playerStats;

    void OnTriggerEnter(Collider other)
    {
        /*
        if (other.GetComponent<Collider>().gameObject.tag == "weapon")
        {
            Transform enemy = GetComponent<Collider>().gameObject.transform.root;
            Animator enemyAnimator = enemy.GetComponent<Animator>();
            AnimatorStateInfo enemyAnimationState = enemyAnimator.GetCurrentAnimatorStateInfo(0);
            if (enemyAnimationState.IsName("Attack"))
            {
                health = health - 10;
            }
        }
        */

        //GameObject collidingObject = other.GetComponent<Collider>().gameObject;
        //string colliderTag = collidingObject.tag;

        // Check to see if the colliding object is a weapon
        if (other.tag == "Weapon")
        {
            Transform enemy = other.transform.root;
            Animator enemyAnimator = enemy.GetComponent<Animator>();
            AnimatorStateInfo enemyAnimationState = enemyAnimator.GetCurrentAnimatorStateInfo(0);
            // Prevent multiple damage occurences per attack
            foreach (string Attack in Attacks)
            {
                if (enemyAnimationState.IsName(Attack))
                {
                    health = health - 10;
                    lastEnemy = enemy.tag;
                }
            }
        }
    }

    void Update()
    {
        if(health <= 0)
        {
            if (lastEnemy == "Player1")
                targetEnemy = "Player2";
            else if(lastEnemy == "Player2")
            {
                targetEnemy = "Player1";
            }
            Destroy(gameObject);
            for (int i = 0; i < banelingNum; i++)
            {
                delta = new Vector3(Random.Range(0, 4), Random.Range(0, 1), Random.Range(0, 4));
                position = gameObject.transform.position + delta;
                Debug.Log(delta);

                clone[i] = Instantiate(baneling, position, Quaternion.identity) as GameObject;
                clone[i].GetComponent<Chase>().tag = targetEnemy;
                
                //clone[i].GetComponent<Rigidbody>().AddForce(delta);
            }
        }
    }

}
