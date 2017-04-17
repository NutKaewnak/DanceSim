using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class AssetFileBrowser : MonoBehaviour, IPointerClickHandler {

	[SerializeField]
	private GameObject assetPanel;

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData) {
		
		string path = EditorUtility.OpenFilePanel ("test", "Assets/Musics", "mp3");

		if (path != "") {
			GameObject audioFile = Instantiate ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/AudioFile.prefab", typeof(GameObject)), assetPanel.transform);
			audioFile.GetComponent<FileIdentity> ().setPath (path);
//			audioFile.transform.parent = assetPanel.transform;
//			audioFile.transform.position = new Vector3 (88.4f, 87.4f, 11.1f);
			Debug.Log (path);
		} else {
			Debug.Log ("no such a file");
		}
	}
	#endregion
}
