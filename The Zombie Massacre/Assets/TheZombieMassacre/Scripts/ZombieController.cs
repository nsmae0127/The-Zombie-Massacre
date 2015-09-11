using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{
	public GameObject target;

	public float speed;

	private Animator anim;

	private GameObject killCount;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();

		killCount = GameObject.FindGameObjectWithTag ("KillCount");
	}
	
	// Update is called once per frame
	void Update ()
	{
		target = GameObject.FindWithTag ("Player");

		Vector3 distance = target.transform.position - transform.position;

		transform.position += distance * speed * Time.deltaTime;
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

	void OnCollisionStay2D (Collision2D col)
	{
		if (col.collider.CompareTag ("Player")) {
			
			// play attack animation
			anim.SetBool ("IsAttack", true);
		}
	}

	void OnCollisionExit2D ()
	{
		anim.SetBool ("IsAttack", false);
	}

	void Dead ()
	{
		anim.SetBool ("isDead", true);

		speed = 0;
	}

	void DestroyGameObject ()
	{
		Destroy (gameObject);
	}
}