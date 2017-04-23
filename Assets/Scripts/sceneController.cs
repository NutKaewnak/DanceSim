using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class sceneController : MonoBehaviour {

	public void BackToEditor() {
		Application.LoadLevel("EditorScene");
    }

    public void goToRecordScene() {
		GameObject audioGroup = GameObject.Find ("AudioGroup");
		audioGroup.transform.SetParent (null);
		DontDestroyOnLoad (audioGroup);
		Application.LoadLevel("RecordScene");
    }
}
