using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimController : MonoBehaviour {
	Animator anim;
	public Scrollbar scroll;
	public float maxlenght = 120;
	public float currentTimer = 0;
	public Text animlenght;
	public Text curSec;
	float min=0;
	float sec=0;
	float mMin=0;
	float mSec=0;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.PlayInFixedTime(0,-1,scroll.value*maxlenght);
		currentTime();
		maxTime();
		if(SimController.instance.state.Equals("play")){
			play();
		}
	}

	void currentTime(){
		min = Mathf.Floor(scroll.value*maxlenght/60);
		sec = (scroll.value*maxlenght)%60;
		curSec.text = (min + "." + Mathf.RoundToInt(sec));
		//send to Simcontroller
		SimController.instance.currentTime = scroll.value*maxlenght;
	
	}
	
	void maxTime(){
		mMin = Mathf.Floor(maxlenght/60);
		mSec = (maxlenght)%60;
		animlenght.text = (mMin + "." + Mathf.RoundToInt(mSec));
	}

	void play(){
		currentTimer = scroll.value * maxlenght;
		currentTimer += Time.deltaTime;
		scroll.value = currentTimer/maxlenght;
	}
}
