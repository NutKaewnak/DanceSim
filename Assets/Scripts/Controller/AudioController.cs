using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	
	public static AudioController instance;

	AudioSource[] audioArr;

	void Start () {
		instance = this;
		audioArr = this.transform.GetComponentsInChildren<AudioSource> ();
	}

	void Update () {
		
	}

	public void playAtTime (int index, float time) {
		if (SimController.instance.isStatePlay()) {
			if (!audioArr [index].isPlaying) {
				Debug.Log ("play");
				audioArr [index].time = time;
				audioArr [index].Play ();
			}
		}
	}

	public void stop (int index) {
		if (audioArr [index].isPlaying) {
			audioArr [index].Stop ();
		}
	}
}