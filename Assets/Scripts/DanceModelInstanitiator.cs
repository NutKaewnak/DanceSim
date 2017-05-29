using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DanceModelInstanitiator : MonoBehaviour {

	public static void instanitiateModel() {
		Instantiate ((GameObject)AssetDatabase.LoadAssetAtPath ("Assets/Prefabs/Model/DancerModel.prefab", 
					typeof(GameObject)), GameObject.Find ("DanceGroup").transform);
	}
}
