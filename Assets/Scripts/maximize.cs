using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maximize : MonoBehaviour {

	public GameObject ColorImagePlane;
	public GameObject stage;
	public GameObject pointMan;
	// Use this for initialization

	Vector3 old_plane_pos;
	Vector3 old_plane_scale;

	Vector3 old_stage_pos;
	Vector3 old_stage_scale;

	Vector3 old_pointMan_pos;
	Vector3 old_pointMan_scale;

	public void expand() {
		old_plane_pos = ColorImagePlane.transform.position;
		old_plane_scale = ColorImagePlane.transform.localScale;

		old_stage_pos = stage.transform.position;
		old_stage_scale = stage.transform.localScale;

		old_pointMan_pos = pointMan.transform.position;
		old_pointMan_scale = pointMan.transform.localScale;

		ColorImagePlane.transform.localScale = new Vector3(6.95F, 1F, 4.4F);
		ColorImagePlane.transform.position = new Vector3(35.2F, 17.6F, 69F);

		stage.transform.localScale = new Vector3(1.64F, 0.4F, 3.0F);
		stage.transform.position = new Vector3(-2.01F,-0.57F,-5F);

		pointMan.transform.localScale -= new Vector3(0.3F, 0.3F, 0.3F);
		pointMan.transform.position = new Vector3(-2.53F,-0.45F,-5F);
	}

	public void compressAndRestore(){
		ColorImagePlane.transform.localScale = old_plane_scale;
		ColorImagePlane.transform.position = old_plane_pos;

		stage.transform.position = old_stage_pos;
		stage.transform.localScale = old_stage_scale;

		pointMan.transform.position = old_pointMan_pos;
		pointMan.transform.localScale = old_pointMan_scale;
	}
}
