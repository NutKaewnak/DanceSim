using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PopUpPanelManager : MonoBehaviour {

	public string name = "";
	public float handleStart = 0;

	void Start() {
		
	}

	void Update() {

	}

	//FOR CONFIRM BUTTON
	public void addMoveBlock () {

		if (name == "") {
			return;
		}
		print ("kuy");
		print (name);
		print (handleStart);
		GameObject moveBlock_prefab = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EditorScene/MoveBlock.prefab", typeof(GameObject));
		Transform choreoGraphInner_panel = ChoreographPanelController.instance.getPanelTransformByHash(ChoreographController.instance.getSelectingModelHash());
		moveBlock_prefab.GetComponent<MoveBlockManager>().setModelHash(ChoreographController.instance.getSelectingModelHash());

		GameObject block = GameObject.Instantiate(moveBlock_prefab, choreoGraphInner_panel);
		block.GetComponent<MoveBlockManager>().setMotionName(name);
		block.GetComponent<MoveBlockManager>().setHandleStart(handleStart);

		MoveController.instance.addAnimClip(name);

		name = "";
		handleStart = 0;
//		Invoke ("addMoveClip", 3f);

	}

	void addMoveClip() {
		Debug.Log ("yah");
		MoveController.instance.addAnimClip(name);

		name = "";
		handleStart = 0;
	}
}
