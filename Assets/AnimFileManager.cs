using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimFileManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler{

	Vector3 startPosition;
	[SerializeField] private string animPath;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
			startPosition = transform.position;
		}
	}
	#endregion

	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
			transform.position = new Vector3 (Input.mousePosition.x - 50f, Input.mousePosition.y - 50f, 0);
		}
	}
	#endregion

	#region IEndDragHandler implementation
	public void OnEndDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
			transform.position = startPosition;
		}
	}
	#endregion
}
