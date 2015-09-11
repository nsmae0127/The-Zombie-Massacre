using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour
{
	public GameObject zombiePrefab;

	private float spawnRate = 5f;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void SpawnZombie ()
	{
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		GameObject zombie = (GameObject)Instantiate (zombiePrefab);

		zombie.transform.position = new Vector2 (max.x, 0);

		ScheduleNextZombieSpawn ();
	}

	void ScheduleNextZombieSpawn ()
	{
		float spawnDelay;

		if (spawnRate > 1f)
			spawnDelay = Random.Range (1f, spawnRate);
		else 
			spawnDelay = 1f;

		Invoke ("SpawnZombie", spawnDelay);
	}

	void IncreaseSpawnRate ()
	{
		if (spawnRate > 1f)
			spawnRate--;

		if (spawnRate == 1f)
			CancelInvoke ("IncreaseSpawnRate");
	}

	public void ScheduleZombieSpawn ()
	{
		Invoke ("SpawnZombie", spawnRate);

		InvokeRepeating ("IncreaseSpawnRate", 0f, 30f);
	}

	public void UnscheduleZombieSpawn ()
	{
		CancelInvoke ("SpawnZombie");
		CancelInvoke ("IncreaseSpawnRate");
	}
}
