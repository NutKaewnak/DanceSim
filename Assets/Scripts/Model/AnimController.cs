using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

public class AnimController : MonoBehaviour {
	[SerializeField] private AnimatorController anim_controller;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
		foreach (AnimationClip clip in anim.runtimeAnimatorController.animationClips) {
			Debug.Log (clip);
		}
	}

	// Update is called once per frame
	void Update () {
		anim.PlayInFixedTime ("testTorNaja", 0, SimController.instance.getCurrentTime ());
	}
}
