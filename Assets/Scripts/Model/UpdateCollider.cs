using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCollider : MonoBehaviour {

	public GameObject childModel;

	// Use this for initialization
	void Start () {
//		this.GetComponent<BoxCollider>().center = new Vector3(1f, 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (childModel.transform.localPosition.y);
		this.GetComponent<BoxCollider>().center = new Vector3(childModel.transform.localPosition.x, 
                                                              1f, 
															  childModel.transform.localPosition.z);
	}
}
