using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{
	public Transform target;
	public float maxDistance;
	public float cd;
	public int damage;
	public PlayerController pc;

	public float speed;

	private Animator anim;

	private GameObject killCount;

	private int maxHealth = 50;
	private int currentHealth;

	public GameObject healthPrefab;
	public GameObject coinPrefab;

	// Use this for initialization
	void Start ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;

		pc = player.GetComponent<PlayerController> ();

		anim = GetComponent<Animator> ();

		killCount = GameObject.FindGameObjectWithTag ("KillCount");

		currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 dir = Vector3.Normalize (target.transform.position - transform.position);
		
		transform.position += dir * speed * Time.deltaTime;
	
		float distance = Vector2.Distance (target.position, transform.position);

		if (distance < maxDistance) {
			pc.IsDamage = true;
			Attack ();
		} else {
			pc.IsDamage = false;
		}

		if (cd > 0) {
			cd = cd * Time.deltaTime;
		}

		if (cd < 0) {
			cd = 0;
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.collider.CompareTag ("PlayerBullet")) {

			// decrease zombie's health

			// play a damaged animation
			Damaged (20);
		}
	}

	void Damaged (int damage)
	{
		if (currentHealth > 0)
			currentHealth -= damage;

		if (currentHealth <= 0) {
			Dead ();
		}
	}

	void Attack ()
	{
		if (cd == 0) {
			anim.SetBool ("IsAttack", true);
			pc.DamagePlayer (10);
	
			if (pc.isDead == true)
				anim.SetBool ("IsAttack", false);
			cd = 2;
		} else {
			anim.SetBool ("IsAttack", false);
		}
	}

	void Dead ()
	{
		anim.SetBool ("IsDead", true);

		speed = 0;

		// update the kill count
		killCount.GetComponent<KillCount> ().Kill += 1;
	}

	void DroppedItem ()
	{
		float dropRate = 2;
		Vector3 dropPos = new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z);

		// dropped item in random rate
		if (Random.Range (0, 3) < 1) {
			if (Random.Range (0, 5) < dropRate) 
				Instantiate (coinPrefab, dropPos, Quaternion.identity);
		} else {
			if (Random.Range (0, 5) < dropRate) 
				Instantiate (healthPrefab, dropPos, Quaternion.identity);
		}
	}

	void DestroyGameObject ()
	{
		Destroy (gameObject);

		DroppedItem ();
	}
}