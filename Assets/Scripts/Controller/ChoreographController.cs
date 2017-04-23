using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

public class ChoreographController : MonoBehaviour {

	public static ChoreographController instance;

//	[SerializeField] 
//	GameObject danceModel;

	GameObject danceModelGroup;
	Animator[] modelAnimatorArr;
	Hashtable animHashTable;

	void Start () {
		instance = this;
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
				Debug.Log (model.gameObject.GetInstanceID());
				animHashTable.Add (model.gameObject.GetInstanceID (), model.gameObject.GetComponent<Animator>());
			}
		}
	}

	public void playMotion (int modelHash, string motionName, float time) {
		Animator playAnim = animHashTable [modelHash] as Animator;
		playAnim.PlayInFixedTime (motionName, 0, time);
	}

	public void playToStart (int modelHash, string motionName) {
		Animator playAnim = animHashTable [modelHash] as Animator;
		playAnim.PlayInFixedTime (motionName, 0, 0);
	}

	public void playToEnd (int modelHash, string motionName) {
		Animator playAnim = animHashTable [modelHash] as Animator;
		playAnim.PlayInFixedTime (motionName, 0, getMotionLengthByName(modelHash, motionName));
	}

	public float getMotionLengthByName (int modelHash, string motionName) {
		Animator playAnim = animHashTable [modelHash] as Animator;
		foreach (AnimationClip ac in playAnim.runtimeAnimatorController.animationClips) {
			if (motionName.Equals (ac.name)) {
				return ac.length;
			}
		}
		return 0f;
	}
}
