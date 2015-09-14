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

	// Use this for initialization
	void Start ()
	{
		GameObject player = GameObject.FindGameObjectWithTag ("Player");
		target = player.transform;

		pc = player.GetComponent<PlayerController> ();

		anim = GetComponent<Animator> ();

		killCount = GameObject.FindGameObjectWithTag ("KillCount");
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3 dir = Vector3.Normalize (target.transform.position - transform.position);
		
		transform.position += dir * speed * Time.deltaTime;
	
		float distance = Vector2.Distance (target.position, transform.position);

		if (distance < maxDistance) {
			Attack ();
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
			Dead ();

			// update the kill count
			killCount.GetComponent<KillCount> ().Kill += 1;
		}
	}

	void Attack ()
	{
		if (cd == 0) {
			anim.SetBool ("IsAttack", true);
			pc.DamagePlayer (damage);
			cd = 2;
		} else {
			anim.SetBool ("IsAttack", false);
		}
	}

	void Dead ()
	{
		anim.SetBool ("IsDead", true);
	}

	void DestroyGameObject ()
	{
		Destroy (gameObject);
	}
}