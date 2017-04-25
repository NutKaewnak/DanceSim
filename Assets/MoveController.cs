using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.Animations;

public class MoveController : MonoBehaviour {

	public static MoveController instance;

	[SerializeField]
	private AnimatorController modelAnimator;
	[SerializeField]
	int selectingModel_hash;
	bool isSelectingModel;
	GameObject danceModelGroup;
	Animator[] modelAnimatorArr;
	Hashtable moveHashTable;



	void Start () {
		instance = this;
		isSelectingModel = false;
		moveHashTable = new Hashtable ();
		updateHash ();
	}

	void Update () {

	}

	public void updateHash () {
		moveHashTable.Clear ();
		danceModelGroup = GameObject.Find ("DanceGroup");
		Transform[] danceModel_arr = danceModelGroup.GetComponentsInChildren<Transform> ();
		foreach (Transform model in danceModel_arr) {
			if (model.gameObject.name.Equals ("U_Character_REF Kinect combined")) {
				moveHashTable.Add (model.gameObject.GetInstanceID (), model.parent.gameObject.GetComponent<Animator> ());
			}
		}
	}

	public void playMotion (int modelHash, string motionName, float time) {
		Animator playAnim = moveHashTable [modelHash] as Animator;
		Debug.Log ("playAnim: " + playAnim);
		if (SimController.instance.isStatePlay ()) {
			playAnim.PlayInFixedTime (motionName, 0, time);
		} else {
			playAnim.Play (motionName, 0, time);
		}
	}

	public float getMotionLengthByName (int modelHash, string motionName) {
		Animator playAnim = moveHashTable [modelHash] as Animator;
		foreach (AnimationClip ac in playAnim.runtimeAnimatorController.animationClips) {
			if (motionName.Equals (ac.name)) {
				return ac.length;
			}
		}
		return 0f;
	}

	public void addAnimClip (string motionName) {
		Debug.Log (motionName);
		AnimationClip motion = (AnimationClip)AssetDatabase.LoadAssetAtPath ("Assets/Recordings/" + motionName + ".anim", typeof(AnimationClip));
		modelAnimator.AddMotion (motion);
	}

	public void setSelectingModelHash (int hash) {
		this.selectingModel_hash = hash;
	}

	public int getSelectingModelHash () {
		return this.selectingModel_hash;
	}

	public void setIsSelectingModel (bool choice) {
		this.isSelectingModel = choice;
	}

	public bool getIsSelectingModel () {
		return this.isSelectingModel;
	}

}
