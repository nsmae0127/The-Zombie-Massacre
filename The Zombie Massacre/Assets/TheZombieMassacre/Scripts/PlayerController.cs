using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	[System.Serializable]
	public class PlayerStats
	{
		public int maxHealth = 100;

		private int curHelath;
		public int CurHelath {
			get {
				return curHelath;
			}
			set {
				curHelath = Mathf.Clamp (value, 0, maxHealth);
			}
		}

		public void Init ()
		{
			CurHelath = maxHealth;
		}
	}

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
}
