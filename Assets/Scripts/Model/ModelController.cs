/*
 * KinectModelController.cs - Moves every 'bone' given to match
 * 				the position of the corresponding bone given by
 * 				the kinect. Useful for viewing the point tracking
 * 				in 3D.
 * 
 * 		Developed by Peter Kinney -- 6/30/2011
 * 
 */

using UnityEngine;
using System;
using System.Collections;

public class ModelController : MonoBehaviour {

	public SkeletonWrapper sw;

	public GameObject Hip_Center;
	public GameObject Spine;
	public GameObject Shoulder_Center;
	public GameObject Head;
	public GameObject Shoulder_Left;
	public GameObject Elbow_Left;
	public GameObject Wrist_Left;
	public GameObject Hand_Left;
	public GameObject Shoulder_Right;
	public GameObject Elbow_Right;
	public GameObject Wrist_Right;
	public GameObject Hand_Right;
	public GameObject Hip_Left;
	public GameObject Knee_Left;
	public GameObject Ankle_Left;
	public GameObject Foot_Left;
	public GameObject Hip_Right;
	public GameObject Knee_Right;
	public GameObject Ankle_Right;
	public GameObject Foot_Right;

	public GameObject PM_Hip_Center;
	public GameObject PM_Spine;
	public GameObject PM_Shoulder_Center;
	public GameObject PM_Head;
	public GameObject PM_Shoulder_Left;
	public GameObject PM_Elbow_Left;
	public GameObject PM_Wrist_Left;
	public GameObject PM_Hand_Left;
	public GameObject PM_Shoulder_Right;
	public GameObject PM_Elbow_Right;
	public GameObject PM_Wrist_Right;
	public GameObject PM_Hand_Right;
	public GameObject PM_Hip_Left;
	public GameObject PM_Knee_Left;
	public GameObject PM_Ankle_Left;
	public GameObject PM_Foot_Left;
	public GameObject PM_Hip_Right;
	public GameObject PM_Knee_Right;
	public GameObject PM_Ankle_Right;
	public GameObject PM_Foot_Right;

	private GameObject[] _bones, pm_bones; //internal handle for the bones of the model
	//private Vector4[] _bonePos; //internal handle for the bone positions from the kinect

	public int player;

	public float scale = 1.0f;

	// Use this for initialization
	void Start () {
		//store bones in a list for easier access
		_bones = new GameObject[] {Hip_Center, Spine, Shoulder_Center, Head,
			Shoulder_Left, Elbow_Left, Wrist_Left, Hand_Left,
			Shoulder_Right, Elbow_Right, Wrist_Right, Hand_Right,
			Hip_Left, Knee_Left, Ankle_Left, Foot_Left,
			Hip_Right, Knee_Right, Ankle_Right, Foot_Right};
		pm_bones = new GameObject[] {PM_Hip_Center, PM_Spine, PM_Shoulder_Center, PM_Head,
			PM_Shoulder_Left, PM_Elbow_Left, PM_Wrist_Left, PM_Hand_Left,
			PM_Shoulder_Right, PM_Elbow_Right, PM_Wrist_Right, PM_Hand_Right,
			PM_Hip_Left, PM_Knee_Left, PM_Ankle_Left, PM_Foot_Left,
			PM_Hip_Right, PM_Knee_Right, PM_Ankle_Right, PM_Foot_Right};
		//_bonePos = new Vector4[(int)BoneIndex.Num_Bones];

	}

	// Update is called once per frame
	void Update () {
		if(player == -1)
			return;
		//update all of the bones positions
		if (sw.pollSkeleton())
		{
			for( int ii = 0; ii < 20; ii++) {
				//_bonePos[ii] = sw.getBonePos(ii);
				//_bones[ii].transform.localPosition = sw.bonePos[player,ii];
				_bones[ii].transform.position = new Vector3(
					pm_bones[ii].transform.position.x * scale,
					pm_bones[ii].transform.position.y * scale,
					pm_bones[ii].transform.position.z * scale);
			}
		}
	}
}
