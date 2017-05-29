using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setStageSize : MonoBehaviour {

	// Use this for initialization
	public void setIncreaseX(){
		gameObject.transform.localScale += new Vector3(0.3F,0,0);
	}
		public void setDecreaseX(){
		gameObject.transform.localScale -= new Vector3(0.3F,0,0);
	}
		public void setIncreaseZ(){
		gameObject.transform.localScale += new Vector3(0,0,0.3F);
	}
		public void setDecreaseZ(){
		gameObject.transform.localScale += new Vector3(0,0,0.3F);
	}
	
}
