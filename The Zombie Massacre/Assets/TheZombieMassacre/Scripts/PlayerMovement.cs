using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed;

	private Rigidbody2D playerRb;

	// Use this for initialization
	void Start ()
	{
		playerRb = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate ()
	{
		float xAxis = Input.GetAxis ("Horizontal");

		playerRb.velocity = new Vector2 (xAxis * moveSpeed, playerRb.velocity.y);
	}
}
