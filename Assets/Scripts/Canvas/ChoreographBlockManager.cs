using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChoreographBlockManager : BlockManager, IDragHandler  {

	/* 1 unit : 1 sec */
	[SerializeField] private int modelHash;
	[SerializeField] private float motionStartTime;
	[SerializeField] private string motionName;
	[SerializeField] private float handleStart, handleEnd;
	[SerializeField] private float motionLength;
	[SerializeField] private float blockHeight;

	void Start () {
		motionStartTime = 0;
		Invoke ("initiate", 0.3f);
	}

	void initiate () {
		motionLength = ChoreographController.instance.getMotionLengthByName (modelHash, motionName);
		this.GetComponent<RectTransform>().sizeDelta = new Vector2 (motionLength, blockHeight);
	}
		
	void Update () {
		updateHandleEndTime ();
		updatePositionOver ();
		commandMotion ();
	}

	void updateHandleEndTime () {
		handleEnd = this.GetComponent<RectTransform>().sizeDelta.x + this.GetComponent<RectTransform>().anchoredPosition.x / 2;
	}

	void updatePositionOver () {
		if (this.GetComponent<RectTransform> ().anchoredPosition.x < 0f) {
			this.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (0f, 5f);
		} else if (this.GetComponent<RectTransform> ().anchoredPosition.x > 960f - this.GetComponent<RectTransform> ().sizeDelta.x * 2) {
			this.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (960f - this.GetComponent<RectTransform> ().sizeDelta.x * 2, 5f);
		}
	}

	void updateSize () {
		if (this.GetComponent<RectTransform> ().sizeDelta.x > motionLength) {
			this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (motionLength, blockHeight);
		} else if (this.GetComponent<RectTransform> ().sizeDelta.x < 1f) {
			this.GetComponent<RectTransform> ().sizeDelta = new Vector2 (1f, blockHeight);
		}
	}

	void commandMotion () {
		float playTime = SimController.instance.getCurrentTime () - handleStart + motionStartTime;
		if (handleStart <= SimController.instance.getCurrentTime() && SimController.instance.getCurrentTime() <= handleEnd) {
			ChoreographController.instance.playMotion (modelHash, motionName, playTime);
		}
	}

	public override void setHandleStart (float x) {
		this.handleStart = x;
		this.GetComponent<RectTransform> ().anchoredPosition = new Vector2(handleStart * 2, 5);
	}

	public override float getStartTime() {
		return this.motionStartTime;
	}

	public override void setStartTime(float time) {
		this.motionStartTime = time;
	}

	public void setModelHash (int hash) {
		this.modelHash = hash;
	}

	public void setMotionName (string name) {
		this.motionName = name;
	}

	public string getMotionName () {
		return this.motionName;
	}

	public override float getHandleStart () {
		return this.handleStart;
	}

	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
			transform.position = new Vector3 (Input.mousePosition.x, transform.position.y, 5);
			this.handleStart = Mathf.Max(0f, this.GetComponent<RectTransform> ().anchoredPosition.x / 2);
		}
	}
	#endregion
}
