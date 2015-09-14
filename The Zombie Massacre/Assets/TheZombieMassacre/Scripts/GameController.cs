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

	public GameObject zombieSpawn;

	public GameObject timer;

	public GameObject killCount;
	
	// Use this for initialization
	void Start ()
	{
		StartGamePlay ();
	}

	void UpdateGameState ()
	{
		switch (gmState) {
		case GameState.GameReady:

			// hide game over image

			// menu button visible

			break;

		case GameState.GamePlay:

			// initiate the kill count 0
			killCount.GetComponent<KillCount> ().Kill = 0;

			// start zombie spawn
			zombieSpawn.GetComponent<ZombieSpawn> ().ScheduleZombieSpawn ();

			// reset timer 0 second

			break;

		case GameState.GameOver:

			// stop zombie spawn
			zombieSpawn.GetComponent<ZombieSpawn> ().UnscheduleZombieSpawn ();

			// stop the timer
			timer.GetComponent<TimeController> ().StopTimeCounter ();

			// game over image visible

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
