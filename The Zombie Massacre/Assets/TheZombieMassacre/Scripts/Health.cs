using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{
	private PlayerController pc;
	private AudioSource soundController;

	public AudioClip getHealth;

	// Use this for initialization
	void Start ()
	{
		pc = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();

		soundController = GameObject.FindGameObjectWithTag ("SoundController").GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag ("Ground")) {
			Debug.Log ("col");
			GetComponent<Rigidbody2D> ().isKinematic = true;
		}
		
		if (col.CompareTag ("Player")) {
			pc.CurrentHealth += 10;

			soundController.clip = getHealth;
			soundController.Play ();
			Destroy (gameObject);
		}
	}
}
