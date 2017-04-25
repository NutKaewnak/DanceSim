using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setSizePanel : MonoBehaviour {
	public GameObject ChgPanel;
	// private RectTransform size;
	private float val;
	public Scrollbar scroll;
	private Vector3 moveSize;
	// Use this for initialization
	void Start () {
		// size = ChgPanel.GetComponent<RectTransform>();
		// val = scroll.value;
	}
	
	// Update is called once per frame
	void Update () {
		if(scroll.value>=1){
			ChgPanel.GetComponent<RectTransform>().position = new Vector3(960,1350,0);
		}
		if(scroll.value<1){
			ChgPanel.GetComponent<RectTransform>().position = new Vector3(960,845,0);
		}
	}

}
