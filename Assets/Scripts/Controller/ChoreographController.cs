using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

public class ChoreographController : MonoBehaviour {

	public static ChoreographController instance;

	[SerializeField] private GameObject danceModel;
	private Animator[] modelAnimatorArr;

	void Start () {
		instance = this;
		modelAnimatorArr = danceModel.transform.GetComponentsInChildren<Animator> ();
	}
		
	void Update () {

	}

	public void playMotion (string motionName, float time) {
		modelAnimatorArr [0].PlayInFixedTime (motionName, 0, time);
	}

	public float getMotionLengthByName (string motionName, int index) {
		foreach (AnimationClip ac in modelAnimatorArr [index].runtimeAnimatorController.animationClips) {
			if (motionName.Equals (ac.name)) {
				return ac.length;
			}
		}
		return 0f;
	}
}
