using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

// ui controller for an individual item in the save list. 
public class SaveListItemController : MonoBehaviour
{    
    private SaveMetadata saveFile; 
    [SerializeField]
    private Text txtSaveTime; 
    [SerializeField]
    private Text txtLevel; 
    [SerializeField]
    private Text txtLocation;    

    internal void SetData(SaveMetadata sf)
    {
        this.saveFile = sf; 
        this.txtSaveTime.text = sf.SaveTime.ToString();
        this.txtLevel.text = string.Format("Lvl:{0}", sf.PlayerLevel); 
        this.txtLocation.text = sf.Location; 
    }
 
    public SaveMetadata SaveFile { get { return this.saveFile; } }
}
