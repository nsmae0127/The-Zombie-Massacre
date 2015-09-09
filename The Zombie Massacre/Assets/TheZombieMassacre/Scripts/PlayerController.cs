using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
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
		Movement ();
	}

	void Movement ()
	{
		float xAxis = Input.GetAxis ("Horizontal");
		
		playerRb.velocity = new Vector2 (xAxis * moveSpeed, playerRb.velocity.y);
	}

	void CameraTowardsPlayer ()
	{
		Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2 (0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.225f;
		min.x = min.x - 0.225f;
	}
}
