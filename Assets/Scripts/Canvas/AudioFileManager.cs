using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioFileManager : MonoBehaviour {

	[SerializeField] private string audioPath;
	[SerializeField] private Text audioName_text;

	// Use this for initialization
	void Start () {
		string[] path_split = audioPath.Split ("/"[0]);
		Debug.Log (path_split [path_split.Length - 1]);
		audioName_text.text = path_split [path_split.Length - 1];
	}

	// Update is called once per frame
	void Update () {

	}

	public void setPath (string path) {
		this.audioPath = path;
	}

	public string getPath (string path) {
		return this.audioPath;
	}

}
