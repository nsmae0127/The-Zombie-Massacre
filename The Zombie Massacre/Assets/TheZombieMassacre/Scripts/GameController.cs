using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour
{
	public enum GameState
	{
		GameReady,
		GamePlay,
		GameOver
	}

	GameState gmState;

	public GameObject player;

	public GameObject zombieSpawn;

	public GameObject timer;

	public GameObject killCount;

	public GameObject result;

	public Text kill;
	
	// Use this for initialization
	void Start ()
	{
		StartGamePlay ();
	}

	void UpdateGameState ()
	{
		switch (gmState) {
		case GameState.GameReady:

			Application.LoadLevel (0);

			break;

		case GameState.GamePlay:

			// player init
			player.GetComponent<PlayerController> ().PlayerInit ();

			// initiate the kill count 0
			killCount.GetComponent<KillCount> ().Kill = 0;

			// start zombie spawn
			zombieSpawn.GetComponent<ZombieSpawn> ().ScheduleZombieSpawn ();

			// reset timer 0 second
			timer.GetComponent<TimeController> ().StartTimeCounter ();

			break;

		case GameState.GameOver:
			PlayerPrefs.SetInt ("KillCount", killCount.GetComponent<KillCount> ().Kill);

			// stop zombie spawn
			zombieSpawn.GetComponent<ZombieSpawn> ().UnscheduleZombieSpawn ();

			// stop the timer
			timer.GetComponent<TimeController> ().StopTimeCounter ();

			// game over image visible
//			gameover.SetActive (true);
			result.SetActive (true);

			kill.text = string.Format ("{0}", PlayerPrefs.GetInt ("KillCount"));

			// change game state to GameStart state after 3 seconds

			break;
		}
	}

	public void SetGameState (GameState state)
	{
		gmState = state;
		UpdateGameState ();
	}

	public void StartGamePlay ()
	{
		gmState = GameState.GamePlay;
		UpdateGameState ();
	}

	public void ChangeToGameReadyState ()
	{
		SetGameState (GameState.GameReady);
	}
}
