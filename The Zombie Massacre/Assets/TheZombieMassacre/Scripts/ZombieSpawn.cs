using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour
{
	public GameObject zombiePrefab;

	private float spawnRate = 5f;

	// Use this for initialization
	void Start ()
	{
		Invoke ("SpawnZombie", spawnRate);
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
	}
}
