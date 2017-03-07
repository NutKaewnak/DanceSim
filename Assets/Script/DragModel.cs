using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragModel : MonoBehaviour
{
	private bool isOver;
	private bool up;
	private Vector3 startPosition;
	public GameObject item;

	void Awake()
	{
		startPosition = item.transform.position;
	}

	void OnMouseEnter()
	{
		isOver = true;
	}

	void OnMouseExit()
	{
		isOver = false;
	}

	IEnumerator OnMouseDown()
	{
		up = false;
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		Vector3 old_pos = ray.origin + (ray.direction * 4.7f);
		while(up == false)
		{
			ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			Vector3 new_pos = ray.origin + (ray.direction * 4.7f);
			Vector3 delta_pos = new_pos - old_pos;
//			Debug.Log ("Delta_pos: " + delta_pos);
			if (new_pos != old_pos) {
				old_pos = new_pos;
			}
			item.transform.position = new Vector3 (item.transform.position.x + delta_pos.x, item.transform.position.y, item.transform.position.z + delta_pos.y);
			yield return new WaitForEndOfFrame();
		}
	}

	void OnMouseUp()
	{
		up = true;
		Vector3 pos = new Vector3(item.transform.position.x, item.transform.position.y, item.transform.position.z);
		item.transform.position = pos;
	}

	public void Reset()
	{
		item.transform.position = startPosition;
	}
		
}
