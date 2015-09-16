using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WeaponController : MonoBehaviour
{
	//	public GameObject[] weapons;

	[SerializeField]
	private int index;

	private Image wp;
	public Sprite[] weaponSprite;

	//	private int weaponNum;

	// Use this for initialization
	void Start ()
	{
//		weaponNum = weapons.Length;

		wp = GetComponent<Image> ();
	}

	// Function to switch weapon
	public void SwitchWeapon ()
	{
		switch (index) {
		case 0:
			// first weapon is pistol
			Debug.Log ("Change a weapon 0");
			wp.sprite = weaponSprite [0];

			index++;

			break;
		case 1:
			// second weapon is shotgun
			Debug.Log ("Change a weapon 1");
			wp.sprite = weaponSprite [1];

			index++;

			break;
		case 2:
			// third weapon is flamethrower
			Debug.Log ("Change a weapon 2");
			wp.sprite = weaponSprite [2];

			index = 0;

			break;
		}
	}
}
