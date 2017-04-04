using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BlockController : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{
	public static GameObject itemBeingDragged;
	Vector3 startPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (transform.position.x);
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
