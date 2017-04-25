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
//		foreach (string guide in AssetDatabase.FindAssets ("t:animation")) {
//			animPath_list.Add(AssetDatabase.GUIDToAssetPath (guide));
//		}
//
//		foreach (string path in animPath_list) {
//			string[] split = path.Split ("/" [0]);
//			if (split [1].Equals ("Recordings")) {
//				animName_list.Add (split [split.Length - 1]);
//			}
//		}
		foreach (string name in animName_list) {
			Debug.Log (name);
		}
	}

	public void addFile () {
		string path = EditorUtility.OpenFilePanel ("test", "Assets/Musics", "wav");
		if (path != "") {
			fileSlot_arr = this.GetComponentsInChildren<FileSlotManager> ();
			foreach (FileSlotManager slot in fileSlot_arr) {
				if (!slot.file) {
					GameObject audioFile = Instantiate ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EditorScene/AudioFile.prefab", typeof(GameObject)), slot.getTransform());
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
		List<string> animPath_list = new List<string> ();
		List<string> name = new List<string> ();
		foreach (string guide in AssetDatabase.FindAssets ("t:animation")) {
			animPath_list.Add(AssetDatabase.GUIDToAssetPath (guide));
		}
		foreach (string path in animPath_list) {
			string[] split = path.Split ("/" [0]);
			if (split [1].Equals ("Recordings")) {
				name.Add (split [split.Length - 1].Split("."[0])[0]);
			}
		}
		return name;
	}

}
