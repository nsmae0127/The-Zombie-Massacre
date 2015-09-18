using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Coin : MonoBehaviour
{
	public Text wallet;

	private PlayerController pc;

	private AudioSource soundController;
	public AudioClip getCoin;
	
	// Use this for initialization
	void Start ()
	{
		pc = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerController> ();
		wallet = GameObject.FindGameObjectWithTag ("Wallet").GetComponent<Text> ();

		soundController = GameObject.FindGameObjectWithTag ("SoundController").GetComponent<AudioSource> ();
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.CompareTag ("Ground")) {
			Debug.Log ("col");
			GetComponent<Rigidbody2D> ().isKinematic = true;
		}

		if (col.CompareTag ("Player")) {
			// add coin on wallet
			pc.Coins += 10;

			wallet.text = string.Format ("{0} G", pc.Coins);

			soundController.clip = getCoin;
			soundController.Play ();

			Destroy (gameObject);
		}
	}
}
