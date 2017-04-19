using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AnimFileManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
	
	public static GameObject itemBeingDragged;
	Vector3 startPosition;

	[SerializeField] private string animPath;
	[SerializeField] private Text animName_text;

	// Use this for initialization
	void Start () {
		animName_text.text = "testTorNaja";
	}

	// Update is called once per frame
	void Update () {
		
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
			transform.position = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, 0);
		}
	}
	#endregion

	#region IEndDragHandler implementation
	public void OnEndDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
			itemBeingDragged = null;
			transform.position = startPosition;
		}
	}
	#endregion
}
