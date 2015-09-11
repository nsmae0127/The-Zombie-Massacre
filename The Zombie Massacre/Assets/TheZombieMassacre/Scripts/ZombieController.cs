using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour
{
	public GameObject target;

	public float speed;

	private Animator anim;

	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();
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

			// play a damaged animation
			Dead ();

			// decrease zombie's health

		}
	}

	void Dead ()
	{
		anim.SetBool ("isDead", true);
	}

	void DestroyGameObject ()
	{
		Destroy (gameObject);
	}
}