using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimFileManager : MonoBehaviour {

	[SerializeField] 
	private string animPath;
	[SerializeField]
	private string animName;
	[SerializeField] 
	private Text animName_text;

	// Use this for initialization
	void Start () {
		animName_text.text = animName;
	}

	public void setAnimName (string name) {
		this.animName = name;
	}

	public string getAnimName () {
		return this.animName;
	}

}
