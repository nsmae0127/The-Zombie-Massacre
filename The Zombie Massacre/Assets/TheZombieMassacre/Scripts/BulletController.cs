using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{
	public GameObject bulletPrefab;
	public GameObject bulletPosition;

	public float fireDelay;
	public float fireOn;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Space) && Time.time > fireOn) {
			
			fireOn = Time.time + fireDelay;

			// instantiate the player's bullet
			GameObject playerBullet = (GameObject)Instantiate (bulletPrefab);

			playerBullet.transform.position = bulletPosition.transform.position;
		}
	}
}
