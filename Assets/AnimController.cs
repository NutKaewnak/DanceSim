using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimController : MonoBehaviour {
	Animator anim;
	public Scrollbar scroll;
	public float maxlenght = 60;
	public Text maxSec;
	public Text curSec;

	// Use this for initialization
	void Start () {
		anim = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.PlayInFixedTime("movement",-1,scroll.value*maxlenght);
		curSec.text=(scroll.value*maxlenght).ToString();
	}

	
}
