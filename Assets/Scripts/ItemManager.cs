using UnityEngine;

public class ItemManager : MonoBehaviour
{
	public CharacterStats playerHealth;
	public GameObject item;
	public float spawnTime = 30f; //Spawn item every 30 seconds
	public Transform[] spawnPoints;
	private float aliveTime = 1f;
	
	
	void Start ()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}
	
	
	void Spawn ()
	{
		if (playerHealth.CurrentHealth <= 0f)
		{
			return;
		}
		int spawnPointIndex = Random.Range (0, spawnPoints.Length);
		Object clonedItem = Instantiate (item, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
	}
}
