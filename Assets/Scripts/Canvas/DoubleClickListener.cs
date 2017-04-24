using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class DoubleClickListener : MonoBehaviour, IPointerClickHandler {
	
	int tap;

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData) {
		tap = eventData.clickCount;
		if (tap == 2) {
			Debug.Log ("double click");
			if (this.GetComponent<AnimFileManager> ()) {
				Instantiate ((GameObject)AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/EditorScene/ChoreographBlock.prefab", 
					typeof(GameObject)), GameObject.Find ("Choreograph Panel/Panel").transform);
			} else if (this.GetComponent<AudioFileManager> ()) {
				GameObject block = Instantiate ((GameObject)AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/EditorScene/AudioBlock.prefab", 
					typeof(GameObject)), GameObject.Find ("AudioGroup").transform);
				block.GetComponent<AudioBlockManager>().setAudioName (this.GetComponent<AudioFileManager> ().getName());
			} else if (this.GetComponent<DanceModelInstanitiator>()) {
				DanceModelInstanitiator.instanitiateModel();
			}
		}
	}
	#endregion
}
