﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AudioBlockManager : MonoBehaviour, IDragHandler {

	/* 1 unit : 1 sec */
	[SerializeField] private float audioStartTime;
	[SerializeField] private string audioName;
	[SerializeField] private float handleStart, handleEnd;

	void Start () {
		audioStartTime = 0;
        Invoke ("initiate", 0.3f);
	}
	
    void initiate () {
		this.GetComponent<RectTransform>().sizeDelta = new Vector2(AudioController.instance.getAudioLengthByName(audioName), 70.69f);
    }

	void Update () {
		updateHandleEndTime ();
		updatePositionOver ();
		updateSize ();
		commandAudio ();
	}

	void updateHandleEndTime () {
		handleEnd = this.GetComponent<RectTransform>().sizeDelta.x + this.GetComponent<RectTransform>().anchoredPosition.x / 2;
	}

	void updatePositionOver () {
		if (this.GetComponent<RectTransform> ().anchoredPosition.x < 0f) {
			this.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0f, 0f);
		} else if (this.GetComponent<RectTransform> ().anchoredPosition.x > 960f - this.GetComponent<RectTransform> ().sizeDelta.x * 2) {
			this.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (960f - this.GetComponent<RectTransform> ().sizeDelta.x * 2, 0f);
		}
	}

	void updateSize () {
		if (this.GetComponent<RectTransform> ().sizeDelta.x > AudioController.instance.getAudioLengthByName (audioName)) {
			this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (AudioController.instance.getAudioLengthByName (audioName), 70f);
		} else if (this.GetComponent<RectTransform> ().sizeDelta.x < 1f) {
			this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (1f, 70f);
		}
	}

	void commandAudio () {
		if (SimController.instance.isStatePlay()) {
			if (handleStart <= SimController.instance.getCurrentTime()) {
				AudioController.instance.playAtTime (audioName, (SimController.instance.getCurrentTime() - handleStart + audioStartTime));
			}
			if (handleEnd <= SimController.instance.getCurrentTime()) {
				AudioController.instance.stop (audioName);
			}
		} else if (!SimController.instance.isStatePlay()) {
			AudioController.instance.stop (audioName);
		}
	}

	public float getStartTime () {
		return this.audioStartTime;
	}

	public void setHandleStart (float x) {
		this.handleStart = x;
		this.GetComponent<RectTransform> ().anchoredPosition = new Vector2(handleStart * 2, 0);
	}

    public void setStartTime (float time) {
        this.audioStartTime = time;
    }

	public void setAudioName (string name) {
		this.audioName = name;
	}

	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
			transform.position = new Vector3 (Input.mousePosition.x, transform.position.y, 0);
			this.handleStart = Mathf.Max(0f, this.GetComponent<RectTransform> ().anchoredPosition.x / 2);
		}
	}
	#endregion
}
