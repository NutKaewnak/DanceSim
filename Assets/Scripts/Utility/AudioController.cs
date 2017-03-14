using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {
	AudioSource[] audioArr;
	public float currentTime;

	void Start() {
		audioArr = this.transform.GetComponentsInChildren<AudioSource> ();
	}

	void Update() {
		currentTime = SimController.instance.currentTime;
		if (Input.GetKeyDown(KeyCode.Return)) {
			audioArr[0].time = currentTime;
			audioArr[0].Play ();
		}
	}
}