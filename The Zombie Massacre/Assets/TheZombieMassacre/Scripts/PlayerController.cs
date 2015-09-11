using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public int health = 100;

	public float moveSpeed;

	private Rigidbody2D playerRb;

	private Animator anim;
	private AudioSource audioSrc;
	public AudioClip footstep;
	public AudioClip fireon;

	public GameObject bulletPrefab;
	public GameObject bulletPosition;
	
	public float fireDelay;
	public float fireOn;
	
	public GameObject gameContrller;

	// Use this for initialization
	void Start ()
	{
		playerRb = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();

		audioSrc = GetComponent<AudioSource> ();
	}

	void FixedUpdate ()
	{
		Movement ();

		CameraTowardsPlayer ();

		FireOn ();
	}

	void OnCollisionStay2D (Collision2D col)
	{
		if (col.collider.CompareTag ("Zombie")) {
			// damaged from zombie, decrease player health
		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if (col.collider.CompareTag ("Zombie")) {
			
			// damaged from zombie, decrease player health

		}
	}

	void Movement ()
	{
		anim.SetFloat ("Speed", Mathf.Abs (Input.GetAxis ("Horizontal")));

		float xAxis = Input.GetAxis ("Horizontal");
		
		playerRb.velocity = new Vector2 (xAxis * moveSpeed, playerRb.velocity.y);

		if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.D)) {
			audioSrc.PlayOneShot (footstep);
		}
	}

	void CameraTowardsPlayer ()
	{
		Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2 (1, 1));

		max.x = max.x - 0.755f;

		if (transform.position.x > max.x) {
			Camera.main.transform.position = new Vector3 (2 * max.x, Camera.main.transform.position.y, Camera.main.transform.position.z);
		}
	}

	void FireOn ()
	{
		anim.SetBool ("IsFireOn", false);
		
		if (Input.GetKeyDown (KeyCode.Space) && Time.time > fireOn) {

			audioSrc.PlayOneShot (fireon);
			
			// play a fire on animation
			anim.SetBool ("IsFireOn", true);
			
			fireOn = Time.time + fireDelay;
			
			// instantiate the player's bullet
			GameObject playerBullet = (GameObject)Instantiate (bulletPrefab);
			
			playerBullet.transform.position = bulletPosition.transform.position;
		}
	}

	void PlayerDead ()
	{
		if (health <= 0) {
			// play the player dead animation
			anim.SetBool ("IsDie", true);

			// change game state to gameover state
			gameContrller.GetComponent<GameController> ().SetGameState (GameController.GameState.GameOver);
		}
	}

	void DestroyGameObject ()
	{
		Destroy (gameObject);
	}
}
