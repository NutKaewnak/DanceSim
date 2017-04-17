using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudioBlockController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	/* 1 unit : 1 sec */
//	public RectTransform handle;
//	public RectTransform slidingArea;
	public RectTransform handle;
	float startTime;
	float endTime;
//	float audioPlayTime;
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
//		Debug.Log (this.GetComponent<RectTransform>().sizeDelta.x);
//		Debug.Log (pos_x);
//		Debug.Log (Mathf.Floor(transform.position.x - pos_x));
//		Debug.Log("handle: " + handle.transform.localPosition.x);
//		Debug.Log ("sliding: " + slidingArea.sizeDelta);

		updateStartTime ();
		updateAudioLength ();
		updateEndTime ();
		commandAudio ();
		Debug.Log(handle.anchoredPosition.x);
		Debug.Log ("startTime: " + startTime);
		Debug.Log ("endTime: " + endTime);
//		Debug.Log ("currentTime: " + SimController.instance.currentTime);
		Debug.Log (audioLength);
//		Debug.Log (transform.position.x);
//		Debug.Log (transform.localScale.x);
	}

	void commandAudio () {
		if (SimController.instance.isStatePlay()) {
			if (startTime <= SimController.instance.getCurrentTime()) {
				AudioController.instance.playAtTime (audioIndex, (SimController.instance.getCurrentTime() - startTime));
			}
			if (endTime <= SimController.instance.getCurrentTime()) {
				AudioController.instance.stop (audioIndex);
			}
		} else if (SimController.instance.isStatePause()) {
			AudioController.instance.stop (audioIndex);
		}
	}

	void updateStartTime () {
		startTime = this.GetComponent<RectTransform>().anchoredPosition.x;
	}

	void updateEndTime () {
		endTime = startTime + audioLength;
	}

	void updateAudioLength () {
		audioLength = this.GetComponent<RectTransform>().sizeDelta.x;
	}

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
			itemBeingDragged = gameObject;
			startPosition = transform.position;
		}
	}
	#endregion

	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
			transform.position = new Vector3 (Input.mousePosition.x, transform.position.y, 0);
		}
	}
	#endregion

	#region IEndDragHandler implementation
	public void OnEndDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
			itemBeingDragged = null;
		}
	}
	#endregion
}
