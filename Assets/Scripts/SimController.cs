using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimController : MonoBehaviour {
	public static SimController instance;
	public float currentTime;
	public string state;
	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setStatePlay(){
		state = "play";
	}

	public void setStatePause(){
		state = "pause";
	}
}
