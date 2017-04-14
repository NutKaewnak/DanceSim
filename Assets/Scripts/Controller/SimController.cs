using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimController : MonoBehaviour {
	
	public static SimController instance;

	[SerializeField]
	private float currentTime;
	[SerializeField]
	private string state;
	[SerializeField]
	private Scrollbar scroll;
	[SerializeField]
	private float maxlenght = 120;
	[SerializeField]
	private Text animlenght;
	[SerializeField]
	private Text curSec;

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

	// CHECK STATE STATUS
	public bool isStateStandby () { return state.Equals ("standby"); }
	public bool isStatePlay () { return state.Equals ("play"); }
	public bool isStatePause () { return state.Equals ("pause"); }

	// GET
	public float getCurrentTime () { return this.currentTime; }
	public string getState () { return this.state; }

}
