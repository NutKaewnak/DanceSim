﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudioBlockManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	/* 1 unit : 1 sec */
	[SerializeField] private float audioStartTime;
	[SerializeField] private int audioIndex = 0;
	[SerializeField] private float handleStart, handleEnd;

	public static GameObject itemBeingDragged;
	Vector3 startPosition;

	// Use this for initialization
	void Start () {
//		transform.position = new Vector3(pos_x, transform.position.y, transform.position.z);
		audioStartTime = 0;
		this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (AudioController.instance.getAudioLengthByIndex(0), 70.69f);
	}
	
	// Update is called once per frame
	void Update () {
		updateHandleStart();
		updateHandleEndTime ();
		commandAudio ();
//		Debug.Log ("endTime: " + endTime);
	}

	void commandAudio () {
		if (SimController.instance.isStatePlay()) {
			if (handleStart <= SimController.instance.getCurrentTime()) {
				AudioController.instance.playAtTime (audioIndex, (SimController.instance.getCurrentTime() - handleStart + audioStartTime));
			}
			if (handleEnd <= SimController.instance.getCurrentTime()) {
				AudioController.instance.stop (audioIndex);
			}
		} else if (!SimController.instance.isStatePlay()) {
			AudioController.instance.stop (audioIndex);
		}
	}

//	void updateStartTime () {
//		startTime = this.GetComponent<RectTransform>().anchoredPosition.x;
//	}

	void updateHandleStart () {
		handleStart = this.GetComponent<RectTransform> ().anchoredPosition.x / 2;
	}

	void updateHandleEndTime () {
		handleEnd = this.GetComponent<RectTransform>().sizeDelta.x + this.GetComponent<RectTransform>().anchoredPosition.x / 2;
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
