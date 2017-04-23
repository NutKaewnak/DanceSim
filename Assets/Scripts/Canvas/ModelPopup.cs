using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelPopup : MonoBehaviour {

  public DragModel dragModel;
	[SerializeField] 
	private GameObject MovePopup;
	[SerializeField] 
	private GameObject PopUp;

	public MoveModel moveModel;
	// Use this for initialization

	void OnMouseDown()
    {
       MovePopup.gameObject.SetActive(true);
       PopUp.gameObject.SetActive(false);
    }

    public void enableMove (){
      moveModel.model = dragModel;
    }
}
