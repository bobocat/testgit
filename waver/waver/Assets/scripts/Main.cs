using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Main : MonoBehaviour {

	public Text timerText;
	[HideInInspector]
	public float timer;
	private bool timerActive = false;

	public static System.Action<string> StopTimerEvent;

	public Color gongedColor;
	public Color goodColor;

	private AudioSource[] allAudioSources;
	void Awake ()
	{
		allAudioSources = FindObjectsOfType (typeof(AudioSource)) as AudioSource[];
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (timerActive){

			timer += Time.deltaTime;

		}

		timerText.text = timer.ToString("###.# sec");

	}

	public void StopAllAudio ()
	{
		foreach (AudioSource audioS in allAudioSources) {
			audioS.Stop ();
		}
	}

	public void StartTimer(){

		timerActive = true;
		timer = 0f;

	}

	public void StopTimer(string reason){
		timerActive = false;

		// stop all the timers on any running acts
		if (StopTimerEvent != null)
			StopTimerEvent(reason);
	}

}
