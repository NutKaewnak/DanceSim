using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoreographPanelController : MonoBehaviour {

	public static ChoreographPanelController instance;
	[SerializeField]
	float lastLength;

	// Use this for initialization
	void Start () {
		instance = this;
	}

	// Update is called once per frame
	void Update () {
		updateLastLength ();
	}

	void updateLastLength () {
		lastLength = 0;
		ChoreographBlockManager[] choreographBlock_arr = this.GetComponentsInChildren<ChoreographBlockManager> ();
		foreach (ChoreographBlockManager block in choreographBlock_arr) {
			RectTransform block_rectTransform = block.gameObject.GetComponent<RectTransform> ();
			float block_length = block_rectTransform.anchoredPosition.x + block_rectTransform.sizeDelta.x * 2;
			if (lastLength == 0 || block_length > lastLength) {
				lastLength = block_length;
			}
		}
	}

	public float getLastLength () {
		return this.lastLength;
	}
}
