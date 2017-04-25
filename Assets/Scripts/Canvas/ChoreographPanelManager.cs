using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoreographPanelManager : MonoBehaviour {

	public static ChoreographPanelManager instance;
	[SerializeField]
	float lastLength;
	[SerializeField]
	int modelHash;

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

	public void setModelHash (int hash) {
		this.modelHash = hash;
	}

	public int getModelHash () {
		return this.modelHash;
	}

	public float getLastLength () {
		return this.lastLength;
	}
}
