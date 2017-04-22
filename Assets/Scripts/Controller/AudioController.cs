using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	
	public static AudioController instance;

	AudioSource[] audioArr;
	Hashtable audioHashTable;

	void Start () {
		instance = this;
		audioArr = this.transform.GetComponentsInChildren<AudioSource> ();
		audioHashTable = new Hashtable ();
		updateHash ();
	}

	void Update () {
		
	}

	void updateHash () {
		foreach (AudioSource audio in audioArr) {
			Debug.Log (audio.name);
			audioHashTable.Add(audio.name, audio);
		}
	}

	public void playAtTime (string audioName, float time) {
		if (SimController.instance.isStatePlay()) {
			AudioSource audio = audioHashTable [audioName] as AudioSource;
			if (!audio.isPlaying) {
				audio.time = Mathf.Min (time, audio.clip.length - 0.01f);
				audio.Play ();
			}
		}
	}

	public void stop (string audioName) {
		AudioSource audio = audioHashTable [audioName] as AudioSource;
		if (audio.isPlaying) {
			audio.Stop ();
		}
	}

	public float getAudioLengthByName (string audioName) {
		// Debug.Log (audioName);
		AudioSource audio = audioHashTable [audioName] as AudioSource;
		return audio.clip.length;
	}

}