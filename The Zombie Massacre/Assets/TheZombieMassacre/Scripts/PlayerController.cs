using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed;

	private Rigidbody2D playerRb;

	Animator anim;

	// Use this for initialization
	void Start ()
	{
		playerRb = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();
	}

	void FixedUpdate ()
	{
		Movement ();

		CameraTowardsPlayer ();
	}

	void Movement ()
	{
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));

		float xAxis = Input.GetAxis ("Horizontal");
		
		playerRb.velocity = new Vector2 (xAxis * moveSpeed, playerRb.velocity.y);
	}

	void CameraTowardsPlayer ()
	{
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.755f;

		if (transform.position.x > max.x) {
			Camera.main.transform.position = new Vector3 (2 * max.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
		}
	}
}
