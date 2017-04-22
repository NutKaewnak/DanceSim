using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class DoubleClickListener : MonoBehaviour {
	
	bool one_click = false;
	bool timer_running;
	float timer_for_double_click;
	//this is how long in seconds to allow for a double click
	[SerializeField] private float delay;
	[SerializeField] private GameObject inner_choreoGraphPanel;

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			if(!one_click) {
				//ENTRY
				one_click = true;
				timer_for_double_click = Time.time;
			} 
			else {
				//DOUBLE CLICK
				one_click = false;
				Debug.Log("click");
				Instantiate ((GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefabs/EditorScene/ChoreographBlock.prefab", typeof(GameObject)), inner_choreoGraphPanel.transform);
			}
		}
		if(one_click) {
			if((Time.time - timer_for_double_click) > delay) {
				//ONE CLICK
				one_click = false;

			}
		}
	}
}
