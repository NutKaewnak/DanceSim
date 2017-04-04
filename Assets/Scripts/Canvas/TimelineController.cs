using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TimelineController : MonoBehaviour, IBeginDragHandler, IEndDragHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	#region IBeginDragHandler implementation
	public void OnBeginDrag (PointerEventData eventData) {
		if (!SimController.instance.state.Equals("standby")) {
			SimController.instance.setStatePause ();
		}
	}
	#endregion

	#region IEndDragHandler implementation
	public void OnEndDrag (PointerEventData eventData) {
		if (!SimController.instance.state.Equals("standby")) {
			SimController.instance.setStatePlay ();
		}
	}
	#endregion
}
