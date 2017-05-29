using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class sceneController : MonoBehaviour {

	public void backToEditor () {
		detachAudioGroup ();
		detachDanceGroup ();
		detachChoreographPanel ();
		Application.LoadLevel("EditorScene");
    }

    public void goToRecordScene() {
		detachAudioGroup ();
		detachDanceGroup ();
		detachChoreographPanel ();
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

	void detachChoreographPanel () {
		GameObject choreograph_panel = GameObject.Find ("Choreograph Panel");
		choreograph_panel.transform.SetParent (null);
		DontDestroyOnLoad (choreograph_panel);
	}
}
