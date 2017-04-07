using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	public static AudioController instance;
	AudioSource[] audioArr;
	public float currentTime;
	float oldTIme;

	void Start() {
		instance = this;
		audioArr = this.transform.GetComponentsInChildren<AudioSource> ();
	}

	void Update() {
		// Update current time
//		currentTime = SimController.instance.currentTime;
//
//		if (SimController.instance.state.Equals ("play")) {
//			if (!audioArr [0].isPlaying) {
//				audioArr [0].time = currentTime;
//				audioArr [0].Play ();
//			}
//		}
//
//		if (SimController.instance.state.Equals ("pause") || SimController.instance.state.Equals ("standby")) {
//			audioArr [0].time = currentTime;
//			audioArr [0].Stop ();
//		}

		//Debug.Log ("currentTime: " + currentTime);
		//Debug.Log ("audioTime: " + audioArr [0].time);
	}

	public void playAtTime (int index, float time) {
		if (SimController.instance.state.Equals ("play")) {
			if (!audioArr [index].isPlaying) {
				Debug.Log ("play");
				audioArr [index].time = time;
				audioArr [index].Play ();
			}
		}
	}

	public void stop (int index) {
		if (SimController.instance.state.Equals ("pause") || SimController.instance.state.Equals ("standby")) {
			audioArr [index].Stop ();
		}
	}
}