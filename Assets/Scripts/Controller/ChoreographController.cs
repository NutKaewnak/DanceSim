using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Animations;

public class ChoreographController : MonoBehaviour {

	public static ChoreographController instance;

	[SerializeField] private GameObject danceModel;
	private Animator[] modelAnimatorArr;

	// Use this for initialization
	void Start () {
		instance = this;
		modelAnimatorArr = danceModel.transform.GetComponentsInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		commandPlay ("test", SimController.instance.getCurrentTime ());	
	}

	public void commandPlay (string motionName, float time) {
		modelAnimatorArr [0].PlayInFixedTime (motionName, 0, time);
	}
}
