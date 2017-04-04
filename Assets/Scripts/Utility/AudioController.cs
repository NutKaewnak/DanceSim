using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	AudioSource[] audioArr;
	public float currentTime;
	float oldTIme;

	void Start() {
		audioArr = this.transform.GetComponentsInChildren<AudioSource> ();
	}

	void Update() {

		// Update current time
		currentTime = SimController.instance.currentTime;

		if (SimController.instance.state.Equals ("play")) {
			if (!audioArr [0].isPlaying) {
				audioArr [0].time = currentTime;
				audioArr [0].Play ();
			}
		}

		if (SimController.instance.state.Equals ("pause")) {
			audioArr [0].time = currentTime;
			audioArr [0].Stop ();
		}

		//Debug.Log ("currentTime: " + currentTime);
		//Debug.Log ("audioTime: " + audioArr [0].time);

	}
}