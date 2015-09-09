using UnityEngine;
using System.Collections;

public class MainController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
	
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
}
