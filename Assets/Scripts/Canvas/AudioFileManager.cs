using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioFileManager : MonoBehaviour {

	[SerializeField] private string audioPath, audioName;
	[SerializeField] private Text audioName_text;

	// Use this for initialization
	void Start () {
		string[] path_split = audioPath.Split ("/"[0]);
		audioName = path_split [path_split.Length - 1];
		audioName_text.text = audioName;
	}

	// Update is called once per frame
	void Update () {

	}

	public void setPath (string path) {
		this.audioPath = path;
	}

	public string getPath () {
		return this.audioPath;
	}

	public string getName () {
		return this.audioName;
	}
}
