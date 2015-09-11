using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KillCount : MonoBehaviour
{
	private Text killCount;

	private int kill;

	public int Kill {
		get {
			return kill;
		}
		set {
			kill = value;
			UpdateKillCount ();
		}
	}

	// Use this for initialization
	void Start ()
	{
		killCount = GetComponent<Text> ();
	}

	void UpdateKillCount ()
	{
		string killStr = string.Format ("{0}", kill);
		killCount.text = killStr;
	}
}
