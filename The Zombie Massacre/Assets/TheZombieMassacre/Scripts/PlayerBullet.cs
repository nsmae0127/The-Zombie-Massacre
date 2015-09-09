using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour
{
	public float speed;

	private Vector2 initPos;

	// Use this for initialization
	void Start ()
	{
		initPos = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector2 position = transform.position;

		position = new Vector2 (position.x + speed * Time.deltaTime, position.y);

		transform.position = position;

		if (transform.position.x > initPos.x + 7f)
			Destroy (gameObject);
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.collider.CompareTag ("Zombie")) {
			
			// decrease zombie's health points (1/3)


			// destroy the bullet gameobejct
			Destroy (gameObject);
		}
	}
}
