using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceGroupController : MonoBehaviour {

	public static DanceGroupController instance;

	void Awake() {
		if (instance == null) {
			instance = this;
		} else {
			if (instance != this) {
				Destroy(this.gameObject);
			}
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
