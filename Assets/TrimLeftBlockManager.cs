using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrimLeftBlockManager : MonoBehaviour, IPointerClickHandler, IDragHandler {

	[SerializeField] RectTransform audioBlock;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		updatePosition ();
	}

	void updatePosition () {
		this.GetComponent<RectTransform> ().anchoredPosition = new Vector2 (this.GetComponent<RectTransform>().sizeDelta.x, 0f);
	}

	#region IPointerClickHandler implementation
	public void OnPointerClick (PointerEventData eventData) {
		Debug.Log("click");
	}
	#endregion

	#region IDragHandler implementation
	public void OnDrag (PointerEventData eventData) {
		if (!SimController.instance.isStatePlay ()) {
//			audioBlock.sizeDelta = new Vector2 (Input.mousePosition.x / 2, 70f);
			audioBlock.anchoredPosition = new Vector2 (Input.mousePosition.x / 2, 0f);
		}
	}
	#endregion
}