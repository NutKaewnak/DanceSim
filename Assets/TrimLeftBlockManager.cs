using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TrimLeftBlockManager : MonoBehaviour, IPointerClickHandler, IDragHandler {

	[SerializeField]
    RectTransform audioBlock;

    [SerializeField]
    AudioBlockManager audioBlockManager;

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
            Vector2 oldPosition = audioBlock.anchoredPosition;
            
			audioBlock.sizeDelta = new Vector2 (audioBlock.sizeDelta.x - (Input.mousePosition.x - oldPosition.x)/4, 70f);
            Debug.Log(audioBlock.sizeDelta.x);
            audioBlock.position = new Vector3(audioBlock.position.x+ ((Input.mousePosition.x - oldPosition.x) / 2), audioBlock.position.y, audioBlock.position.z);
//			audioBlock.anchoredPosition = new Vector2 (Input.mousePosition.x / 2, 0f);
//          audioBlock.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (Input.mousePosition.x - oldPosition.x) / 2);
            audioBlockManager.shiftStartTime((audioBlock.anchoredPosition.x - oldPosition.x) / 2);

        }
	}
	#endregion
}