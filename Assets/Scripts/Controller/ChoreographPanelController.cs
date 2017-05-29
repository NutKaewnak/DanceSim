using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoreographPanelController : MonoBehaviour {

	public static ChoreographPanelController instance;
	Hashtable panelHashTable;


	// Use this for initialization
	void Start () {
		instance = this;
		panelHashTable = new Hashtable ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void updateHash () {
		panelHashTable.Clear ();
        Debug.Log(this.GetComponentsInChildren<ChoreographPanelManager>().Length);
		foreach (ChoreographPanelManager panel in this.GetComponentsInChildren<ChoreographPanelManager> ()) {
			panelHashTable.Add (panel.getModelHash (), panel);
		}
	}

	public Transform getPanelTransformByHash (int hash) {
		ChoreographPanelManager panel = panelHashTable [hash] as ChoreographPanelManager;
		return panel.transform;
	}

	public int getPanelCount () {
		return this.GetComponentsInChildren<ChoreographPanelManager> ().Length;
	}

	public float getLastLengthByHash (int hash) {
		ChoreographPanelManager panel = panelHashTable [hash] as ChoreographPanelManager;
		return panel.getLastLength ();
	}

}
