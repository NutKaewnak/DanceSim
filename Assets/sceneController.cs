﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneController : MonoBehaviour {

	   public void BackToEditor() {
        Application.LoadLevel("EditorScene");
    }

    	public void goToRecordScene(){
    		Application.LoadLevel("RecordScene");
    	}
}
