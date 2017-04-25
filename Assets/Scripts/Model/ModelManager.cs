using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;
    [SerializeField] private Light light;
    [SerializeField] private GameObject popUp;
	[SerializeField] private Color modelColor;
    private bool checkClickmove = false;
    private bool checkClickmoveForPopUp = false;
    private Vector3 oldPosition;
    private Vector3 newPosition;

    private int checkDancerHash;

    void Start () {
		modelColor = new Color( Random.value, Random.value, Random.value, 1.0f );
		Debug.Log (modelColor);
    }
    void Update() {
        checkCollider();
        checkLightingOff();
    }

    private void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            selectModel();
        }
        if (Input.GetMouseButtonDown(1)) {
            popUpModel();
        }
    }

    void OnMouseDrag () {
        if(checkClickmove){
            Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
            curPosition.y = transform.position.y;
            transform.position = curPosition;
        }
    }

    /*void OnMouseUp () {
        light.gameObject.SetActive(false);
    }*/

	void popUpModel () {
        Debug.Log("popup");
		Vector3 popPOS = new Vector3(transform.position.x-1f,transform.position.y+3f, 0);
		if(!checkClickmoveForPopUp){
			popUp.gameObject.SetActive(true);
		}
		popUp.transform.position = popPOS;
		screenPoint = Camera.main.WorldToScreenPoint(transform.position);
		offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void selectModel () {
        Debug.Log("select");
        light.gameObject.SetActive(true);
        int modelHash = this.transform.GetChild (0).gameObject.GetInstanceID ();
		ChoreographController.instance.setSelectingModelHash (modelHash);
		ChoreographController.instance.setIsSelectingModel (true);
        checkDancerHash = ChoreographController.instance.getSelectingModelHash();
    }

    void checkCollider () {
        if (SimController.instance.isStateStandby())  {
            this.GetComponent<BoxCollider>().enabled = true;
        } else {
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }

    public void setIsClickmoveForPopUp () {
        checkClickmoveForPopUp = false;
    }

    public void setMoved () {
        checkClickmoveForPopUp = true;
        checkClickmove = true;
        oldPosition = gameObject.transform.position;
    }
    public Vector3 getOldPosition () {
        return oldPosition;
    }

    public Vector3 getNewPosition () {
        newPosition = gameObject.transform.position;
        return newPosition;
    }

    public void setMoveFalse () {
        checkClickmove = false;
        checkClickmoveForPopUp = false;
    }
    public void checkLightingOff () {
        if (checkDancerHash != ChoreographController.instance.getSelectingModelHash()) {
            light.gameObject.SetActive(false);
        }
    }
}
