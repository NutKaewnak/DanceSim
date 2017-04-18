using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoreographBlockManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	/* 1 unit : 1 sec */
	[SerializeField] private float startTime;
	[SerializeField] private float endTime;
	[SerializeField] private float motionLength;
	[SerializeField] private string motionName;

	public static GameObject itemBeingDragged;
	Vector3 startPosition;

	void Start () {
		startTime = 0;
		this.GetComponent<RectTransform>().sizeDelta = new Vector2 (ChoreographController.instance.getMotionLengthByName (motionName, 0), 70.69f);
	}
		
	void Update () {
//		updateStartTime ();
		updateAudioLength ();
		updateEndTime ();
		commandMotion ();
	}

	void commandMotion () {
		ChoreographController.instance.playMotion (motionName, SimController.instance.getCurrentTime ());
	}

//	void updateStartTime () {
//		startTime = this.GetComponent<RectTransform>().anchoredPosition.x;
//	}

	void updateEndTime () {
		endTime = this.GetComponent<RectTransform>().sizeDelta.x + this.GetComponent<RectTransform>().anchoredPosition.x;
	}

	void updateAudioLength () {
		motionLength = this.GetComponent<RectTransform>().sizeDelta.x;
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
