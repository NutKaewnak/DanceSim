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
				Debug.Log ("currentTime: " + SimController.instance.getCurrentTime ());
				Debug.Log ("time: " + time);
				Debug.Log (Mathf.Min (time, audioArr [index].clip.length - 0.01f));
				audioArr [index].time = Mathf.Min (time, audioArr [index].clip.length - 0.01f);
				audioArr [index].Play ();
			}
		}
	}

	public void stop (int index) {
		if (audioArr [index].isPlaying) {
			audioArr [index].Stop ();
		}
	}

	public float getAudioLengthByIndex (int index) {
		return audioArr [index].clip.length;
	}

}