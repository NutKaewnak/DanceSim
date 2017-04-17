using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class AssetFileBrowser : MonoBehaviour, IPointerClickHandler {

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData) {
		Debug.Log ("test");
		Debug.Log(EditorUtility.OpenFilePanel ("test", "Assets/Musics", "mp3"));
	}
	#endregion
}
