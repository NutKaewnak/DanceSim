using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeObjectPosition : MonoBehaviour {

    public GameObject obj;
    public Vector3 newPosition;
    public void changeTransform()
    {
        this.obj.transform.position = this.newPosition;
    }
}
