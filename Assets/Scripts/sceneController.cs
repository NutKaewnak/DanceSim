using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class sceneController : MonoBehaviour {

	public void backToEditor () {
		detachAudioGroup ();
		detachDanceGroup ();
		Application.LoadLevel("EditorScenePTor");
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
		DanceGroupMoverController.instance.danceGroup.SetActive (!DanceGroupMoverController.instance.danceGroup.activeSelf);
		DanceGroupMoverController.instance.danceGroup.transform.SetParent (null);
		DontDestroyOnLoad (DanceGroupMoverController.instance.danceGroup);
	}
}
