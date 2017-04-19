using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragModel : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    [SerializeField] private Light light;

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        if(Input.GetMouseButtonDown(0)){
            light.gameObject.SetActive(true);
        }
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.y = transform.position.y;
        transform.position = curPosition;
    }

    void OnMouseUp(){
        light.gameObject.SetActive(false);
    }

}
