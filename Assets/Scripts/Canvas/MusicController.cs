using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	public void PlayMusic () {
		this.GetComponent<AudioSource> ().Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
