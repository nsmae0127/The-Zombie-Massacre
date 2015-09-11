using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject bulletPosition;

	public float fireDelay;
	public float fireOn;

	private Animator anim;

	private AudioSource audioSrc;
	
	// Use this for initialization
	void Start ()
	{
		anim = GetComponent<Animator> ();

		audioSrc = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		anim.SetBool ("IsFireOn", false);

		if (Input.GetKeyDown (KeyCode.Space) && Time.time > fireOn) {
		
			audioSrc.Play ();

			// play a fire on animation
			anim.SetBool ("IsFireOn", true);

			fireOn = Time.time + fireDelay;

			// instantiate the player's bullet
			GameObject playerBullet = (GameObject)Instantiate (bulletPrefab);

			playerBullet.transform.position = bulletPosition.transform.position;
		}
	}
}
