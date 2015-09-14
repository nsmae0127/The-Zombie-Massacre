using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainController : MonoBehaviour
{
	public GameObject muteBtn;

	public Sprite muteSprite;
	public Sprite unmuteSprite;

	private Image muteImg;
	private bool isMute;
	
	// Use this for initialization
	void Start ()
	{
		muteImg = muteBtn.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	public void PlayGame (string level)
	{
		Application.LoadLevel (level);
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}

	public void AudioIsMute ()
	{
		isMute = !isMute;

		AudioSource audioSrc = GetComponent<AudioSource> ();

		if (isMute) {
			muteImg.sprite = muteSprite;
			audioSrc.mute = true;
		} else {
			muteImg.sprite = unmuteSprite;
			audioSrc.mute = false;
		}
	}
}
