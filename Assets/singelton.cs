using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singelton : MonoBehaviour {
    public static singelton instance;

	// Use this for initialization
	void Awake () {
		if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (instance != this)
            {
                Destroy(this);
            }
        }
	}
}
