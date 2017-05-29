using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webCam : MonoBehaviour {
	  public RawImage rawimage;
	// Use this for initialization
	void Start () {
		 WebCamTexture webcamTexture = new WebCamTexture();
         rawimage.texture = webcamTexture;
         webcamTexture.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
