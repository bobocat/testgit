using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActButton : MonoBehaviour {

	public Text localTimerText;
	public bool testingGitStuff;
	private Main main;
	private bool actInProgress = false;
	public AudioClip music;

	private TouchScreenKeyboard keyboard;

	private enum actStatusType{waiting, finished, gonged, scored};
	private actStatusType actStatus = actStatusType.waiting;

	void OnEnable(){
		Main.StopTimerEvent += StopAct;
	}
	
	void OnDisable(){
		Main.StopTimerEvent -= StopAct;
	}

	// Use this for initialization
	void Start () {

		main = GameObject.Find("main").GetComponent<Main>();

	}
	
	// Update is called once per frame
	void Update () {

		if (actInProgress)
		{
			localTimerText.text = main.timer.ToString("###.#");
		}

		if (keyboard != null && keyboard.done && actStatus == actStatusType.finished)
		{
			localTimerText.text = keyboard.text;
			actStatus = actStatusType.scored;
		}

	}

	public void StartAct(){
		actInProgress = true;
		main.StartTimer();
		if (music != null)
			GetComponent<AudioSource>().PlayOneShot(music);
	}

	private void GetScore(){

		string inputText = "";
		keyboard = TouchScreenKeyboard.Open(inputText,TouchScreenKeyboardType.NumberPad);

	}

	public void StopAct(string reason){

		if (actInProgress)
		{
			main.StopAllAudio();
			actInProgress = false;
			if (reason == "gonged")
			{
				GetComponent<Image>().color = main.gongedColor;
				actStatus = actStatusType.gonged;
			}

			else
			{
				GetComponent<Image>().color = main.goodColor;
				actStatus = actStatusType.finished;
				localTimerText.text = "Score!";
				GetScore();
			}
		}
	}
}
