using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closePop : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private GameObject popUp;
	 void OnMouseDown()
    {
       Debug.Log("Close");
        popUp.gameObject.SetActive(false);
    }
}
