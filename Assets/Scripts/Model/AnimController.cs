using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

public class AnimController : MonoBehaviour {
	
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		anim.PlayInFixedTime ("testTorNaja", 0, SimController.instance.getCurrentTime ());
	}
}
