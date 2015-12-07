using UnityEngine;

public class ItemManager : MonoBehaviour
{
	CharacterStats player1Health;
	CharacterStats player2Health;

	public GameObject item;
	public bool isBuff;
	public float spawnTime = 30f; //Spawn item every 30 seconds
	public Transform[] spawnPoints;
	private float aliveTime = 1f;
	private Object clonedItem;

	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		//temp
		//player1Health.TakeDamage (40);
	}

	void Update(){
			
	}
	
	
	void Spawn ()
	{
		if (isBuff) {
			if(GameObject.FindGameObjectsWithTag("SwampBuff").Length > 0){
				return;
			}
		}
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		clonedItem = Instantiate (item, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
	
}
