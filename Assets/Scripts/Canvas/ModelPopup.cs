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

     [SerializeField] 
    private Text MovePopupText;

    public MoveModel moveModel;
    public GameObject setCameraTopFront;
    // Use this for initialization

    void OnMouseDown()
    {
        MovePopupText.gameObject.SetActive(true);
       MovePopup.gameObject.SetActive(true);
       PopUp.gameObject.SetActive(false);
       moveModel.model = dragModel;
       dragModel.setMoved();
       setCameraTopFront.GetComponent<ChangeObjectPosition>().changeTransform();
     }
}
