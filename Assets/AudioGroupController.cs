using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGroupController : MonoBehaviour {

	public static AudioGroupController instance;
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
		AudioBlockManager[] audioBlock_arr = this.GetComponentsInChildren<AudioBlockManager> ();
		foreach (AudioBlockManager block in audioBlock_arr) {
			RectTransform block_rectTransform = block.gameObject.GetComponent<RectTransform> ();
			float block_length = block_rectTransform.anchoredPosition.x / 2 + block_rectTransform.sizeDelta.x;
			if (lastLength == 0 || block_length > lastLength) {
				lastLength = block_length;
			}
		}
	}

	public float getLastLength () {
		return this.lastLength;
	}
}
