using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	//START X = 88, END X = 453
	//4 units = 1 secs
	//scaleX = 0.2 => 25 secs
	const float pos_x = 90.2f;

	float startTime;
	float endTime;
	float audioPlayTime;
	float audioLength;
	int audioIndex = 0;

//	public float scale_x = 0.2f;

	public static GameObject itemBeingDragged;
	Vector3 startPosition;

	// Use this for initialization
	void Start () {
//		transform.position = new Vector3(pos_x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (this.GetComponent<RectTransform>().sizeDelta.x);
//		Debug.Log (pos_x);
//		Debug.Log (Mathf.Floor(transform.position.x - pos_x));

		updateStartTime ();
		updateEndTime ();
		updateAudioLength ();
		commandAudio ();
//		Debug.Log ("startTime: " + startTime);
//		Debug.Log ("endTime: " + endTime);
//		Debug.Log ("currentTime: " + SimController.instance.currentTime);
		Debug.Log (audioLength);
//		Debug.Log (transform.position.x);
//		Debug.Log (transform.localScale.x);
	}

	void commandAudio () {
		if (SimController.instance.state.Equals ("play")) {
			if (startTime <= SimController.instance.currentTime) {
				AudioController.instance.playAtTime (audioIndex, (SimController.instance.currentTime - startTime));
			}
			if (endTime <= SimController.instance.currentTime) {
				AudioController.instance.stop (audioIndex);
			}
		} else if (SimController.instance.state.Equals ("pause")) {
			AudioController.instance.stop (audioIndex);
		}
	}

	void updateStartTime () {
		startTime = Mathf.Floor(this.GetComponent<RectTransform>().anchoredPosition.x - pos_x)*(30.59835f/160f);
	}

	void updateEndTime () {
		endTime = startTime + audioLength;
	}

	void updateAudioLength () {
		audioLength = this.GetComponent<RectTransform>().sizeDelta.x * (22.68017f/621.5995f);
	}

	void setPosition_X (float x) {
		transform.position = new Vector3(x, transform.position.y, transform.position.z);
	}

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData) {
		itemBeingDragged = gameObject;
		startPosition = transform.position;
	}
	#endregion

	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData) {
		transform.position = new Vector3(Input.mousePosition.x, transform.position.y, 0);
	}
	#endregion

	#region IEndDragHandler implementation
	public void OnEndDrag (PointerEventData eventData) {
		itemBeingDragged = null;
	}
	#endregion
}
