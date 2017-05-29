using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopAtController : MonoBehaviour {
	[SerializeField]
	private Scrollbar scrollStartAt;
	[SerializeField]
	private Scrollbar scrollStopAt;
	[SerializeField]
	private Text StopAt;
	[SerializeField]
	private float currentTime;
	[SerializeField]
	private float maxlenght = 900;

	[SerializeField]
	private Button playBtn;

	[SerializeField]
	private Button StandbyBtn;

	float currentTimer = 0;
	float min = 0;
	float sec = 0;
	float mMin = 0;
	float mSec = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// Debug.Log("Stop : "+scrollStopAt.value);
		checkStop();
		currentTimeCounter ();
	}

	void currentTimeCounter () {
		min = Mathf.Floor(scrollStopAt.value*maxlenght / 60);
		sec = (scrollStopAt.value * maxlenght) % 60;
		StopAt.text = (min + "." + Mathf.RoundToInt(sec));
		currentTime = scrollStopAt.value * maxlenght;
	}

	void checkStop(){
		if(scrollStartAt.value>=scrollStopAt.value){
			SimController.instance.setStatePause();
			playBtn.gameObject.SetActive(true);
			StandbyBtn.gameObject.SetActive(false);
			scrollStartAt.value=scrollStopAt.value;
		}
		if(scrollStopAt.value<=scrollStartAt.value){
			scrollStopAt.value=scrollStartAt.value;
		}
	}
}
