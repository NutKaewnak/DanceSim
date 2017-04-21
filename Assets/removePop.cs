using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removePop : MonoBehaviour {
	[SerializeField] private GameObject Model;
	
	// Use this for initialization

	 void OnMouseDown()
    {
    	Destroy(Model);
       Debug.Log("RemoveNa");
    }
	
}
