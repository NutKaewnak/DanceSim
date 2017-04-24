using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragModel : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    [SerializeField] private Light light;
    [SerializeField] private GameObject popUp;
    private bool checkClickmove = false;
    private bool checkClickmoveForPopUp = false;
    private Vector3 oldPosition;
    private Vector3 newPosition;

    void Start () {
		
    }


 
    void OnMouseDown()
    {
        Vector3 popPOS = new Vector3(transform.position.x-1f,transform.position.y+3f, 0);
//		int modelHash = this.transform.GetChild (0).GetInstanceID ();
        if(!checkClickmoveForPopUp){
            popUp.gameObject.SetActive(true);
        }
        popUp.transform.position = popPOS;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        light.gameObject.SetActive(true);
//		Debug.Log (modelHash);

    }

    void OnMouseDrag()
    {
        if(checkClickmove){
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            curPosition.y = transform.position.y;
            transform.position = curPosition;
        }
    }

    void OnMouseUp(){
        light.gameObject.SetActive(false);
    }

    public void setIsClickmoveForPopUp(){
        checkClickmoveForPopUp = false;
    }

    public void setMoved(){
        checkClickmoveForPopUp = true;
        checkClickmove = true;
        oldPosition = gameObject.transform.position;
    }
    public Vector3 getOldPosition(){
        return oldPosition;
    }

    public Vector3 getNewPosition(){
        newPosition = gameObject.transform.position;
        return newPosition;
    }
}
