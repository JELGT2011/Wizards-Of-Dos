using UnityEngine;

public class ItemManager : MonoBehaviour
{
	public CharacterStats player1Health;
	public CharacterStats player2Health;
	public GameObject item;
	public bool isBuff;
	public float spawnTime = 30f; //Spawn item every 30 seconds
	public Transform[] spawnPoints;
	private float aliveTime = 1f;
	
	
	void Awake ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{
		if (isBuff) {
			if(player1Health.HasBuff("BigTreeGrace") || player2Health.HasBuff("BigTreeGrace") || GameObject.FindGameObjectsWithTag("SwampBuff").Length > 0){
				return;
			}
		}
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Object clonedItem = Instantiate (item, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
