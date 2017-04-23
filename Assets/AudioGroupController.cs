using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioGroupController : MonoBehaviour {

	public List<GameObject> audioGameobject_list;

	[SerializeField] 
	private GameObject audioGroup;
	Transform[] audioTransform_arr;

	// Use this for initialization
	void Start () {
		audioTransform_arr = audioGroup.GetComponentsInChildren<Transform> ();
		updateAudioBlock ();
		DontDestroyOnLoad (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void updateAudioBlock () {
		audioGameobject_list = new List<GameObject> ();
		foreach (Transform audioTransform in audioTransform_arr) {
			if (audioTransform.GetComponent<AudioBlockManager> ()) {
				Debug.Log ("add block");
				Debug.Log (audioTransform.gameObject);
				audioGameobject_list.Add(audioTransform.gameObject);
			}
		}
	}

	public void checkAudioBlock () {
		foreach (GameObject temp in audioGameobject_list) {
			Debug.Log (temp);
		}
	}

}
