using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseApplication : MonoBehaviour {

    private void OnMouseDown()
    {
        print("Kuy");
        Application.Quit();
    }
}
