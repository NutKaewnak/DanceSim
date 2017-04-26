using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceGroupMoverController : MonoBehaviour {

	public static DanceGroupMoverController instance;
	public GameObject danceGroup, choreograph_panel;


	void Awake() {
		if (instance == null) {
			instance = this;
			DontDestroyOnLoad(this);
		}
		else {
			if (instance != this) {
				Destroy(this);
			}
		}
	}

	// Use this for initialization
	void Start () {
		danceGroup = GameObject.Find ("DanceGroup");
        choreograph_panel = GameObject.Find("Choreograph Panel");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
