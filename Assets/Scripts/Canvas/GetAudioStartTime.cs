using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAudioStartTime : MonoBehaviour {
    public AudioBlockManager audioBlockMan;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.GetComponent<Text>().text = audioBlockMan.getStartTime().ToString();
	}
}
