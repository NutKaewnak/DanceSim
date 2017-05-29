using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playController : MonoBehaviour {
	[SerializeField]
	private float currentTime;
	[SerializeField]
	private Scrollbar scroll;
	[SerializeField]
	private InputField startAt;
	[SerializeField]
	private InputField stopAt;
	private float maxlenght = 900;


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
		currentTimeCounter ();
	}

	void currentTimeCounter () {
		min = Mathf.Floor(scroll.value*maxlenght / 60);
		sec = (scroll.value * maxlenght) % 60;
		startAt.text = (min + "." + Mathf.RoundToInt(sec));
		currentTime = scroll.value * maxlenght;
	}
}
