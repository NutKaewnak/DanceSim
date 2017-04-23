using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class sceneController : MonoBehaviour {

	public void backToEditor () {
		Debug.Log ("test");
		detachAudioGroup ();
		detachDanceGroup ();
		Application.LoadLevel("EditorScene");
    }

    public void goToRecordScene() {
		detachAudioGroup ();
		detachDanceGroup ();
		Application.LoadLevel("RecordScene");
    }

	void detachAudioGroup () {
		GameObject audioGroup = GameObject.Find ("AudioGroup");
		audioGroup.transform.SetParent (null);
		DontDestroyOnLoad (audioGroup);
	}

	void detachDanceGroup () {
		GameObject danceGroup = GameObject.Find ("DanceGroup");
		danceGroup.transform.SetParent (null);
		danceGroup.SetActive (!danceGroup.activeSelf);
		DontDestroyOnLoad (danceGroup);
	}
}
