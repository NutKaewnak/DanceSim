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
    private bool checkMouseUp = false;
    private bool hasBeenDraged = false;
    private Transform oldPosition;
    private Transform newPosition;

    void start(){
    }


 
    void OnMouseDown()
    {
        Vector3 popPOS = new Vector3(transform.position.x-1f,transform.position.y+3f, 0);
        if(!checkClickmove){
            popUp.gameObject.SetActive(true);
        }
        popUp.transform.position = popPOS;
        screenPoint = Camera.main.WorldToScreenPoint(transform.position);
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        light.gameObject.SetActive(true);
    }

    void OnMouseDrag()
    {
        if(checkClickmove){
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            curPosition.y = transform.position.y;
            transform.position = curPosition;
            hasBeenDraged = true;
        }
    }

    void OnMouseUp(){
        light.gameObject.SetActive(false);

        if (hasBeenDraged){
            checkMouseUp = true;
        }
    }

    public void setMoved(){
        checkClickmove = true;
        oldPosition = gameObject.transform;
    }

    public bool getCheckEndDrag(){
        return checkMouseUp;
    }

    // public void setCheckEndDrag(){
    //     if(!checkMouseUp){
    //         checkMouseUp=true;
    //     }
    //     else
    //         checkMouseUp=false;
    // }
}
