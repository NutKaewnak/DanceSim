using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrimRightBlockManager : MonoBehaviour, IPointerClickHandler, IDragHandler {

	[SerializeField]
    RectTransform audioBlock;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		updatePosition ();
	}

	void updatePosition () {
		this.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (audioBlock.sizeDelta.x, 0f);
	}

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData) {
		Debug.Log("click");
	}
	#endregion

	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
            Vector2 oldPosition = audioBlock.anchoredPosition;
            //			transform.position = new Vector3 (Input.mousePosition.x, transform.position.y, 0);
            audioBlock.sizeDelta = new Vector2 ((Input.mousePosition.x - oldPosition.x) / 2, 70f);
		}
	}
	#endregion
}