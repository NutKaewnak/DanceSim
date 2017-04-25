using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelPopup : MonoBehaviour {

    public ModelManager dragModel;
    [SerializeField] 
    private GameObject MovePopup;
    [SerializeField] 
    private GameObject PopUp;

    public MoveModel moveModel;
    public GameObject setCameraTopFront;

	public Button closeBtn;
    // Use this for initialization


    void OnMouseDown()
    {
		closeBtn.gameObject.SetActive (true);
       MovePopup.gameObject.SetActive(true);
       PopUp.gameObject.SetActive(false);
       moveModel.model = dragModel;
       dragModel.setMoved();
       setCameraTopFront.GetComponent<ChangeObjectPosition>().changeTransform();
    }
}
