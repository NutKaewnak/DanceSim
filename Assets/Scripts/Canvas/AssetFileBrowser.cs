using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AssetFileBrowser : MonoBehaviour {

	private FileSlotManager[] fileSlot_arr;
	private List<string> animName_list;


	void Start () {
		animName_list = new List<string> (getAllName());
		updateFile ();
	}

	public void updateFile () {
		fileSlot_arr = this.GetComponentsInChildren<FileSlotManager> ();
		foreach (string animName in animName_list) {
			foreach (FileSlotManager slot in fileSlot_arr) {
				if (!slot.file) {
					GameObject animFile_prefab = (GameObject)Resources.Load ("Prefabs/EditorScene/AnimFile", typeof(GameObject));
					GameObject animFile = Instantiate (animFile_prefab, slot.getTransform ());
					animFile.GetComponent<RectTransform> ().anchoredPosition = Vector2.zero;
					animFile.GetComponent<AnimFileManager> ().setAnimName (animName);
					break;
				}
			}
		}
	}

	public void addFile () {
		string path = EditorUtility.OpenFilePanel ("test", "Assets/Musics", "wav");
		if (path != "") {
			fileSlot_arr = this.GetComponentsInChildren<FileSlotManager> ();
			foreach (FileSlotManager slot in fileSlot_arr) {
				if (!slot.file) {
					GameObject audioFile_prefab = (GameObject)Resources.Load ("Prefabs/EditorScene/AudioFile", typeof(GameObject));
					GameObject audioFile = Instantiate (audioFile_prefab, slot.getTransform());
					audioFile.GetComponent<RectTransform> ().anchoredPosition = Vector2.zero;
					audioFile.GetComponent<AudioFileManager> ().setPath (path);
					break;
				}
			}
		} else {
			Debug.Log ("no such a file");
		}
	}

	List<string> getAllName () {
		List<string> name = new List<string> ();
		foreach (AnimationClip anim in Resources.FindObjectsOfTypeAll (typeof(AnimationClip))) {
			name.Add (anim.name);
		}
		return name;
	}

}
