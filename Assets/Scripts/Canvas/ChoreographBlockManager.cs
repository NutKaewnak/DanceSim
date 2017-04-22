using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoreographBlockManager : MonoBehaviour, IDragHandler {

	/* 1 unit : 1 sec */
	[SerializeField] private float motionStartTime;
	[SerializeField] private string motionName;
	[SerializeField] private float handleStart, handleEnd;

	void Start () {
		motionStartTime = 0;
		Invoke ("initiate", 0.3f);
	}

	void initiate () {
		this.GetComponent<RectTransform>().sizeDelta = new Vector2 (ChoreographController.instance.getMotionLengthByName (motionName, 0), 70.69f);
	}
		
	void Update () {
		updateHandleStartTime ();
		updateHandleEndTime ();
		updatePositionOver ();
		commandMotion ();
	}

	void updateHandleStartTime () {
		handleStart = this.GetComponent<RectTransform>().anchoredPosition.x / 2;
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

	void commandMotion () {
		if (handleStart <= SimController.instance.getCurrentTime() && handleEnd >= SimController.instance.getCurrentTime()) {
			ChoreographController.instance.playMotion (motionName, SimController.instance.getCurrentTime () - handleStart + motionStartTime);
		}
	}

	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
			transform.position = new Vector3 (Input.mousePosition.x, transform.position.y, 0);
		}
	}
	#endregion
}
