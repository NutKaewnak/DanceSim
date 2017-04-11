using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimController : MonoBehaviour {
	
	public static SimController instance;
	public float currentTime;
	public string state;

	public Scrollbar scroll;
	public float maxlenght = 120;
	public Text animlenght;
	public Text curSec;

	float currentTimer = 0;

	float min = 0;
	float sec = 0;
	float mMin = 0;
	float mSec = 0;


	// Use this for initialization
	void Start () {
		instance = this;
		state = "standby";
	}

	// Update is called once per frame
	void Update () {
//		Debug.Log ("state: " + state);
		currentTimeCounter ();
		maxTime ();
		stateCommand ();
	}

	void currentTimeCounter () {
		min = Mathf.Floor(scroll.value*maxlenght / 60);
		sec = (scroll.value * maxlenght) % 60;
		curSec.text = (min + "." + Mathf.RoundToInt(sec));
		currentTime = scroll.value * maxlenght;
	}

	void maxTime () {
		mMin = Mathf.Floor(maxlenght/60);
		mSec = (maxlenght)%60;
		animlenght.text = mMin + "." + Mathf.RoundToInt(mSec);
	}

	void play () {
		currentTimer = scroll.value * maxlenght;
		currentTimer += Time.deltaTime;
		scroll.value = currentTimer / maxlenght;
	}

	void stateCommand () {
		if (state.Equals("play")) {
			play();
		}
	}


	// SET STATE
	public void setStatePlay(){
		state = "play";
	}

	public void setStatePause(){
		if(!state.Equals("standby")){
			state = "pause";
		}	
	}

	public void setStateStandBy(){
		state = "standby";
	}

}
