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
			if (this.GetComponent<AnimFileManager> ()) {
				if (ChoreographController.instance.getIsSelectingModel()) {
					addChoreoGraphBlock ();
				} else {
					//Did not select model
					Debug.Log ("have not selected model");
				}
			} else if (this.GetComponent<AudioFileManager> ()) {
				addAudioBlock ();
			}
		}
	}
	#endregion

	void addChoreoGraphBlock () {
		GameObject choreoGraphBlock_prefab = (GameObject)AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/EditorScene/ChoreographBlock.prefab", typeof(GameObject));
		choreoGraphBlock_prefab.GetComponent<ChoreographBlockManager> ().setModelHash (ChoreographController.instance.getSelectingModelHash ());
		Transform choreoGraphInner_panel = GameObject.Find ("Choreograph Panel/Panel").transform;
		Instantiate (choreoGraphBlock_prefab, choreoGraphInner_panel);
	}

	void addAudioBlock () {
		GameObject block = Instantiate ((GameObject)AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/EditorScene/AudioBlock.prefab", 
			typeof(GameObject)), GameObject.Find ("AudioGroup").transform);
		block.GetComponent<AudioBlockManager>().setAudioName (this.GetComponent<AudioFileManager> ().getName());
	}
}
