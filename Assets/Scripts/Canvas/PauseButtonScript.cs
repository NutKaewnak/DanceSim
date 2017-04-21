using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtonScript : MonoBehaviour {
	public Button btn;
	public Button pausingButton;
	public Button stanbyButton;
	// Use this for initialization
	void Start () {
		btn.GetComponent<Button> ().onClick.AddListener (toPausing);
	}
	
	// Update is called once per frame
	void toPausing(){
		if(stanbyButton.gameObject.activeInHierarchy){
			pausingButton.gameObject.SetActive (true);
			btn.gameObject.SetActive(false);
		}
	}
}
