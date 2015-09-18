using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
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

	public bool isDead;

	public Slider hpBar;

	private int maxHealth;

	private int coins;

	public int Coins {
		get {
			return coins;
		}
		set {
			coins = value;
		}
	}

	[SerializeField]
	private int
		currentHealth;

	public int CurrentHealth {
		get {
			return currentHealth;
		}
		set {
			currentHealth = value;
		}
	}

	[SerializeField]
	private bool
		isDamage;

	public bool IsDamage {
		get {
			return isDamage;
		}
		set {
			isDamage = value;
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		playerRb = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();

		audioSrc = GetComponent<AudioSource> ();

		isDead = false;

		maxHealth = 100;
		currentHealth = maxHealth;
	}

	void FixedUpdate ()
	{
		Movement ();

		CameraTowardsPlayer ();

		FireOn ();

		hpBar.value = currentHealth * 0.01f;
	}

	public void PlayerInit ()
	{
		// player health 100
		currentHealth = 100;

		// player position
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

	public void DamagePlayer (int damage)
	{
		if (isDamage == true) {
			currentHealth -= damage;
			isDamage = false;
		}

		if (currentHealth <= 0) {
			isDead = true;
			PlayerDead ();
		}
	}

	void PlayerDead ()
	{
		if (isDead == true) {
			// play the player dead animation
			anim.SetBool ("IsDie", true);
			isDead = false;
		} else {
			anim.SetBool ("IsDie", false);
		}

		// change game state to gameover state
		gameContrller.GetComponent<GameController> ().SetGameState (GameController.GameState.GameOver);
	}	

	void DestroyGameObject ()
	{
		Destroy (gameObject);
	}
}