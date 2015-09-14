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

	private bool isDead;

	public Image hp;
	private float cachedY;
	private float minXValue;
	private float maxXValue;
	public int maxHealth;
	private int currentHealth;
	public int CurrentHealth {
		get {
			return currentHealth;
		}
		set {
			currentHealth = value;
//			HandleHealth ();
			InvokeRepeating ("decreaseHealth", 0f, 2f);
		}
	}
	
	// Use this for initialization
	void Start ()
	{
		playerRb = GetComponent<Rigidbody2D> ();

		anim = GetComponent<Animator> ();

		audioSrc = GetComponent<AudioSource> ();

		isDead = false;

		currentHealth = maxHealth;

//		HealthInit ();
	}

	void decreaseHealth ()
	{
		print (currentHealth);
		float calcHealth = currentHealth / maxHealth;
		SetHealth (calcHealth);
	}

	void SetHealth (float myHealth)
	{
		hp.fillAmount = myHealth;
	}

	void FixedUpdate ()
	{
		Movement ();

		CameraTowardsPlayer ();

		FireOn ();
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
		if (currentHealth > 0) 
			CurrentHealth -= damage;

		if (currentHealth <= 0) {
			PlayerDead ();
			isDead = true;
		}
	}

	void PlayerDead ()
	{
		if (isDead == false)
		// play the player dead animation
			anim.SetBool ("IsDie", true);
		else 
			anim.SetBool ("IsDie", false);

		// change game state to gameover state
		gameContrller.GetComponent<GameController> ().SetGameState (GameController.GameState.GameOver);
	}

//	private void HandleHealth ()
//	{
//		float currentXValue = MapValues (currentHealth, 0, maxHealth, minXValue, maxXValue);
//
//		print (cachedY);
//		hpTransform.position = new Vector2 (currentXValue, cachedY);
//
////		visualHp.fillAmount = Mathf.Lerp (visualHp.fillAmount, currentXValue, Time.deltaTime * 10);
//	}
//
//	private void HealthInit ()
//	{
//		cachedY = hpTransform.position.y;
//		maxXValue = hpTransform.position.x;
//		minXValue = hpTransform.position.x - hpTransform.rect.width;
//		currentHealth = maxHealth;
//	}
//
//	private float MapValues (float x, float inMin, float inMax, float outMin, float outMax)
//	{
//		return (x - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
//	}

	void DestroyGameObject ()
	{
		Destroy (gameObject);
	}
}
