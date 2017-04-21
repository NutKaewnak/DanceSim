using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class ChoreographPanelManager : MonoBehaviour, IDropHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#region IDropHandler implementation
	public void OnDrop (PointerEventData eventData) {
		if (AnimFileManager.itemBeingDragged && AnimFileManager.itemBeingDragged.GetComponent<AnimFileManager>()) {
			Instantiate ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EditorScene/ChoreographBlock.prefab", typeof(GameObject)), this.gameObject.transform);
		}
	}
	#endregion
}
