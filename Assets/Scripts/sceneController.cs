using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class sceneController : MonoBehaviour {

	public void backToEditor () {
		Debug.Log ("test");
		detachAudioGroup ();
		Application.LoadLevel("EditorScene");
    }

    public void goToRecordScene() {
		detachAudioGroup ();
		Application.LoadLevel("RecordScene");
    }

	void detachAudioGroup () {
		GameObject audioGroup = GameObject.Find ("AudioGroup");
		audioGroup.transform.SetParent (null);
		DontDestroyOnLoad (audioGroup);
	}
}
