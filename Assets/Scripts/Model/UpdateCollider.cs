using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCollider : MonoBehaviour {

	public GameObject childModel;
	BoxCollider box_collider;

	Transform childTrasform;

	void Awake()
	{
		childTrasform = childModel.transform;
	}

	// Use this for initialization
	void Start () {
//		this.GetComponent<BoxCollider>().center = new Vector3(1f, 1f, 1f);
		box_collider = this.GetComponent<BoxCollider>();
		//Debug.Log ("child: " + childModel.transform.localPosition.y);
		//box_collider.center = new Vector3(childModel.transform.localPosition.x, 
			//							  box_collider.center.y + (childModel.transform.localPosition.y - 0), 
			//							  childModel.transform.localPosition.z);
		//Debug.Log ("box: " + box_collider.center.y);
	}
	
	// Update is called once per frame
	void Update () {
		box_collider.center = new Vector3(childModel.transform.localPosition.x, 
										  box_collider.center.y, 
										  childModel.transform.localPosition.z);
	}
}
