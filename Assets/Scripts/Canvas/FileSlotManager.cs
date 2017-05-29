using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileSlotManager : MonoBehaviour {

	public Transform file {
		get {
			if (transform.childCount > 0) {
				return transform.GetChild(0);
			}
			return null;
		}
	}

	public Transform getTransform () {
		return this.transform;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
