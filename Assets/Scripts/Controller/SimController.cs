﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SimController : MonoBehaviour {
	
	public static SimController instance;

	[SerializeField]
	private float currentTime;
	[SerializeField]
	private string state;
	[SerializeField]
	private Scrollbar scroll;
	[SerializeField]
	private float maxlenght = 900;
	[SerializeField]
	private Text animlenght;
	[SerializeField]
	private Text curSec;
	[SerializeField]
	private GameObject ruler;

	float currentTimer = 0;
	float min = 0;
	float sec = 0;
	float mMin = 0;
	float mSec = 0;

	

	// Use this for initialization
	void Start () {
		instance = this;
		state = "standby";
		moveAudioGroup ();
		moveDanceGroup ();
		moveChoreographPanel ();
	}

	// Update is called once per frame
	void Update () {
		currentTimeCounter ();
		maxTime ();
		stateCommand ();
		rulerScaler ();
	}

	void currentTimeCounter () {
		min = Mathf.Floor (scroll.value*maxlenght / 60);
		sec = (scroll.value * maxlenght) % 60;
		// curSec.text = (min + "." + Mathf.RoundToInt(sec));
		curSec.text = min + ".";
		if(Mathf.RoundToInt(sec)/10<1){
			curSec.text += 0;
		}
		curSec.text += Mathf.RoundToInt(sec);
		currentTime = scroll.value * maxlenght;
	}

	void maxTime () {
		mMin = Mathf.Floor (maxlenght/60);
		mSec = (maxlenght) % 60;
		// animlenght.text = mMin + "." + Mathf.RoundToInt(mSec);
		animlenght.text = mMin + ".";
		if(Mathf.RoundToInt(mSec)/10<1){
			animlenght.text += 0;
		}
		animlenght.text += Mathf.RoundToInt(mSec);
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

	void rulerScaler (){
		Vector3 moveRuler = ruler.transform.position;
		Vector3 moveScoll = scroll.transform.position;
		if(Application.loadedLevelName == "EditorScene"){
			// move at 7 min
			if(scroll.value*maxlenght>=420){
				moveRuler.x =-840;
				moveScoll.x =-849;
				scroll.transform.position = moveScoll;
				ruler.transform.position = moveRuler;
			}
			if(scroll.value*maxlenght<420){
				moveRuler.x =0;
				moveScoll.x =-9;
				scroll.transform.position = moveScoll;
				ruler.transform.position = moveRuler;
			}
		}
	}

	void moveAudioGroup () {
		GameObject audioGroup = GameObject.Find ("AudioGroup");
		if (audioGroup) {
			audioGroup.transform.SetParent(GameObject.Find ("Timeline").transform);
			audioGroup.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0, -195f);
		}
	}

	void moveDanceGroup () {
		GameObject danceGroup = GameObject.Find ("DanceGroup");
		if (danceGroup) {
			danceGroup.transform.SetParent (GameObject.Find ("Show").transform);
		}
	}

	void moveChoreographPanel () {
		GameObject choreograph_panel = GameObject.Find ("Choreograph Panel");
		if (choreograph_panel) {
			choreograph_panel.transform.SetParent(GameObject.Find ("Timeline").transform);
		}
	}

	// SET STATE
	public void setStatePlay () {
		state = "play";
	}

	public void setStatePause(){
		if (!state.Equals("standby")) {
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
