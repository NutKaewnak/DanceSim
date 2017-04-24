using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class removeAudioBlock : MonoBehaviour {
    [SerializeField]
    private GameObject obj;

    // Use this for initialization

    public void OnMouseDown()
    {
        destroyAudioBlock();
    }

    public void destroyAudioBlock()
    {
        Destroy(obj);
        Debug.Log("RemoveNa");
    }

}