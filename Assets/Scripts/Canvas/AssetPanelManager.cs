﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;
#endif

public class AssetPanelManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject animFile = Instantiate ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/AnimFile.prefab", typeof(GameObject)), this.gameObject.transform);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void updateAnimFile () {

	}
}
