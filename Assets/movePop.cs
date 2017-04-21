using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePop : MonoBehaviour {
	[SerializeField] private GameObject MovePop;
	[SerializeField] private GameObject PopUp;
	// Use this for initialization

	 void OnMouseDown()
    {
       MovePop.gameObject.SetActive(true);
       PopUp.gameObject.SetActive(false);
       Debug.Log("Movena");
    }
}
