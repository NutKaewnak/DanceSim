using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileIdentity : MonoBehaviour {

	[SerializeField] private string path;

	public void setPath (string new_path) {
		this.path = new_path;
	}

	public string getPath () {
		return this.path;
	}

}
