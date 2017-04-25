using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEditor.Animations;

public class ChoreographController : MonoBehaviour {

	public static ChoreographController instance;

	[SerializeField]
	private AnimatorController modelAnimator;
	int selectingModel_hash;
	bool isSelectingModel;
	GameObject danceModelGroup;
	Animator[] modelAnimatorArr;
	Hashtable animHashTable;



	void Start () {
		instance = this;
		isSelectingModel = false;
		animHashTable = new Hashtable ();
		updateHash ();
	}
		
	void Update () {

	}

	void updateHash () {
		danceModelGroup = GameObject.Find ("DanceGroup");
		Transform[] danceModel_arr = danceModelGroup.GetComponentsInChildren<Transform> ();
		foreach (Transform model in danceModel_arr) {
			if (model.gameObject.name.Equals ("U_Character_REF Kinect combined")) {
//				Debug.Log (model.gameObject.GetInstanceID());
				animHashTable.Add (model.gameObject.GetInstanceID (), model.gameObject.GetComponent<Animator>());
			}
		}
	}

	public void playMotion (int modelHash, string motionName, float time) {
		Animator playAnim = animHashTable [modelHash] as Animator;
		if (SimController.instance.isStatePlay ()) {
			playAnim.PlayInFixedTime (motionName, 0, time);
		} else {
			playAnim.Play (motionName, 0, time);
		}
	}

//	public void playToStart (int modelHash, string motionName) {
//		Animator playAnim = animHashTable [modelHash] as Animator;
//		playAnim.speed = -100;
//	}
//
//	public void playToEnd (int modelHash, string motionName) {
//		Animator playAnim = animHashTable [modelHash] as Animator;
//		playAnim.speed = 100;
//	}

	public float getMotionLengthByName (int modelHash, string motionName) {
		Animator playAnim = animHashTable [modelHash] as Animator;
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
