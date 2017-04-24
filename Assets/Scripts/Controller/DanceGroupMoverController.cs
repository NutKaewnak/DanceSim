using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceGroupMoverController : MonoBehaviour {

	public static DanceGroupMoverController instance;
	public GameObject danceGroup;


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
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
