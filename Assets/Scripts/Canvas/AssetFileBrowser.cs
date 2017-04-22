using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class AssetFileBrowser : MonoBehaviour, IPointerClickHandler {

	[SerializeField]
	private GameObject assetPanel;

	private FileSlotManager[] fileSlot_arr;

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData) {
		
		string path = EditorUtility.OpenFilePanel ("test", "Assets/Musics", "mp3");

		if (path != "") {
			fileSlot_arr = assetPanel.GetComponentsInChildren<FileSlotManager> ();
			foreach (FileSlotManager slot in fileSlot_arr) {
				if (!slot.file) {
					GameObject audioFile = Instantiate ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EditorScene/AudioFile.prefab", typeof(GameObject)), slot.getTransform());
					audioFile.GetComponent<AudioFileManager> ().setPath (path);
				}
			}
		} else {
			Debug.Log ("no such a file");
		}
	}
	#endregion
}
