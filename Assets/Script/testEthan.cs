using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEthan : MonoBehaviour {
	
	
	public Transform pointMan_head;
	public Transform pointMan_spine;
	// public Transform pointMan_C_shoulder;
	public Transform pointMan_L_shoulder;
	public Transform pointMan_R_shoulder;
	public Transform pointMan_L_elbow;
	public Transform pointMan_R_elbow;
	public Transform pointMan_L_wrist;
	public Transform pointMan_R_wrist;
	public Transform pointMan_L_hand;
	public Transform pointMan_R_hand;
	public Transform pointMan_C_hip;
	public Transform pointMan_L_hip;
	public Transform pointMan_R_hip;
	public Transform pointMan_L_knee;
	public Transform pointMan_R_knee;
	public Transform pointMan_L_ankle;
	public Transform pointMan_R_ankle;
	public Transform pointMan_L_foot;
	public Transform pointMan_R_foot;

	public Transform model_head;
	public Transform model_spine;
	// public Transform model_C_shoulder;
	public Transform model_L_shoulder;
	public Transform model_R_shoulder;
	public Transform model_L_elbow;
	public Transform model_R_elbow;
	public Transform model_L_wrist;
	public Transform model_R_wrist;
	public Transform model_L_hand;
	public Transform model_R_hand;
	public Transform model_C_hip;
	public Transform model_L_hip;
	public Transform model_R_hip;
	public Transform model_L_knee;
	public Transform model_R_knee;
	public Transform model_L_ankle;
	public Transform model_R_ankle;
	public Transform model_L_foot;
	public Transform model_R_foot;

	// Use this for initialization
	void Start () {
		//Debug.Log ("Skeleton: " + skeleton.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("Pointman: " + pointMan_head.transform.position);
		Debug.Log ("Model: " + model_head.transform.position);

		model_head.transform.position = pointMan_head.transform.position;
		model_spine.transform.position = pointMan_spine.transform.position;
		// model_C_shoulder.transform.position = pointMan_C_shoulder.transform.position;
		model_L_shoulder.transform.position = pointMan_L_shoulder.transform.position;
		model_R_shoulder.transform.position = pointMan_R_shoulder.transform.position;

		model_L_elbow.transform.position = pointMan_L_elbow.transform.position;
		model_R_elbow.transform.position = pointMan_R_elbow.transform.position;
		model_L_wrist.transform.position = pointMan_L_wrist.transform.position;
		model_R_wrist.transform.position = pointMan_R_wrist.transform.position;
		model_L_hand.transform.position = pointMan_L_hand.transform.position;
		model_R_hand.transform.position = pointMan_R_hand.transform.position;
		// model_C_hip.transform.position = pointMan_C_hip.transform.position;
		model_L_hip.transform.position = pointMan_L_hip.transform.position;
		model_R_hip.transform.position = pointMan_R_hip.transform.position;
		model_L_knee.transform.position = pointMan_L_knee.transform.position;
		model_R_knee.transform.position = pointMan_R_knee.transform.position;
		model_L_ankle.transform.position = pointMan_L_ankle.transform.position;
		model_R_ankle.transform.position = pointMan_R_ankle.transform.position;
		model_L_foot.transform.position = pointMan_L_foot.transform.position;
		model_R_foot.transform.position = pointMan_R_foot.transform.position;
	


		//Debug.Log ("test: " + this.GetComponent<Transform>().position);
		//Debug.Log ("Skeleton: " + skeleton.transform.position);
		//skeleton.transform.Translate(1,1,1);
	}
}
