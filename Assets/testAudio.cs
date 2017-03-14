using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class testAudio : MonoBehaviour {
	AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Return)) {
			audio.time = 40f;
			audio.Play ();
		}
		Debug.Log(audio.timeSamples);
	}
}