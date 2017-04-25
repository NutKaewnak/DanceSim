using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
#if UNITY_EDITOR 
using UnityEditor;
#endif

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
			} else if (this.GetComponent<DanceModelInstanitiator>())
            {
                addDancerModel ();
            }
		}
	}
    #endregion

    void addChoreoGraphBlock() {
        GameObject choreoGraphBlock_prefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EditorScene/ChoreographBlock.prefab", typeof(GameObject));
        Transform choreoGraphInner_panel = GameObject.Find("Choreograph Panel/Panel").transform;
        choreoGraphBlock_prefab.GetComponent<ChoreographBlockManager>().setModelHash(ChoreographController.instance.getSelectingModelHash());

        GameObject block = GameObject.Instantiate(choreoGraphBlock_prefab, choreoGraphInner_panel);
        block.GetComponent<ChoreographBlockManager>().setMotionName(this.GetComponent<AnimFileManager>().getAnimName());
        block.GetComponent<ChoreographBlockManager>().setHandleStart(ChoreographPanelController.instance.getLastLength() / 2);

        ChoreographController.instance.addAnimClip(this.GetComponent<AnimFileManager>().getAnimName());
    }

    void addAudioBlock() {
        GameObject audioBlock_prefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EditorScene/AudioBlock.prefab", typeof(GameObject));
        Transform audioGroup = GameObject.Find("AudioGroup").transform;
        audioBlock_prefab.GetComponent<AudioBlockManager>().setAudioName(this.GetComponent<AudioFileManager>().getName());

        GameObject block = Instantiate(audioBlock_prefab, audioGroup);
        block.GetComponent<AudioBlockManager>().setHandleStart(AudioGroupController.instance.getLastLength() / 2);

        AudioController.instance.addAudioClip(this.GetComponent<AudioFileManager>().getPath());
    }

    void addDancerModel () {
        Instantiate((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/Model/DancerModel.prefab",
                    typeof(GameObject)), GameObject.Find("DanceGroup").transform);
		ChoreographController.instance.updateHash ();
    }
}
