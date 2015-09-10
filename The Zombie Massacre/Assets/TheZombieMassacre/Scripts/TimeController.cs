using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeController : MonoBehaviour
{
	// reference to the timer UI Text
	private Text timeText;

	// the time when the user clicks on play
	private float startTime;

	// the ellapsed time after the user clicks on play
	private float ellapsedTime;

	// flag to start the counter
	public bool startCounter;

	private int minutes;
	private int seconds;

	// Use this for initialization
	void Start ()
	{
		timeText = GetComponent<Text> ();

		startCounter = true;
	}

	// Update is called once per frame
	void Update ()
	{
		if (startCounter) {
			//computer the ellapsed time 
			ellapsedTime = Time.time - startTime;

			minutes = (int)ellapsedTime / 60; //get the minutes
			seconds = (int)ellapsedTime % 60; //get the seconds

			//update the time counter UI Text
			timeText.text = string.Format ("{0:00}:{1:00}", minutes, seconds);
		}
	}

	// Function to start the time counter
	public void StartTimeCounter ()
	{
		startTime = Time.time;
		startCounter = true;
	}

	// Function to stop the time counter
	public void StopTimeCounter ()
	{
		startCounter = false;
	}

}
