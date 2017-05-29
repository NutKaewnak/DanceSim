using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removePop : MonoBehaviour {
    [SerializeField]
    private GameObject obj;

    // Use this for initialization

    public void OnMouseDown()
    {
    	Destroy(obj);
       Debug.Log("RemoveNa");
    }
	
}
