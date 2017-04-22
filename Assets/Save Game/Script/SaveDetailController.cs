using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.IO;

// UI controller for the detail section (right half) of the save game screen. This displays the data for the selected save file. 
public class SaveDetailController : MonoBehaviour
{    
    public event Action<SaveMetadata> Load;
    public event Action<SaveMetadata> Save;
    public event Action<SaveMetadata> Delete; 

    private SaveMetadata saveFile; 
    private bool canSave; 

    [SerializeField] private Text txtSaveTime; 
    [SerializeField] private Text txtTimePlayed; 
    [SerializeField] private Text txtLocation; 
    [SerializeField] private Text txtNumSaves; 
    [SerializeField] private Text txtPlayerName; 
    [SerializeField] private Text txtLevel; 
    [SerializeField] private Text txtHP; 
    [SerializeField] private Image imgScreenshot; 
    
    [SerializeField] private GameObject btnLoad; 
    [SerializeField] private GameObject btnSave; 
    [SerializeField] private GameObject btnDelete;     

    public void SetData(SaveMetadata sf)
    {
        this.saveFile = sf;
        this.txtSaveTime.text = string.Format("Last Saved: {0}", sf.SaveTime);
        this.txtTimePlayed.text = string.Format("Time Played: {0:d2}:{1:d2}:{2:d2}", sf.TimePlayed.Hours, sf.TimePlayed.Minutes, sf.TimePlayed.Seconds);
        this.txtLocation.text = string.Format("Location: {0}", sf.Location);
        this.txtNumSaves.text = string.Format("# Saves: {0}", sf.NumberOfSaves);
        this.txtPlayerName.text = string.Format("Name: {0}", sf.PlayerName);
        this.txtLevel.text = string.Format("Level: {0}", sf.PlayerLevel);
        this.txtHP.text = string.Format("HP: {0}/{1}", sf.PlayerHP, sf.PlayerMaxHP);        
        this.btnSave.SetActive(this.canSave);        
        this.btnLoad.SetActive(true); 
        this.btnDelete.SetActive(true); 

        Texture2D texture = this.LoadScreenshot(sf.Index);     
        if(texture != null)
        {
            this.imgScreenshot.gameObject.SetActive(true);
            this.DestroySprite();
            this.imgScreenshot.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);
        }
        else this.imgScreenshot.gameObject.SetActive(false);
    }

    private Texture2D LoadScreenshot(int index)
    {
        Texture2D texture = null; 
        string file = Path.Combine(Application.persistentDataPath, string.Format("saveScreen{0}.png", index)); 
        if(File.Exists(file))
        {
            byte[] bytes = File.ReadAllBytes(file); 
            if(bytes != null && bytes.Length > 0)
            {
                texture = new Texture2D(2, 2); 
                texture.LoadImage(bytes); 
            }
        }
        return texture; 
    }

    public void Clear()
    {
        this.saveFile = null; 
        this.txtSaveTime.text = "";
        this.txtTimePlayed.text = "";
        this.txtLocation.text = "";
        this.txtNumSaves.text = "";
        this.txtPlayerName.text = "";
        this.txtLevel.text = "";
        this.txtHP.text = "";
        this.btnSave.SetActive(false);
        this.btnLoad.SetActive(false); 
        this.btnDelete.SetActive(false); 
        this.DestroySprite();
        this.imgScreenshot.gameObject.SetActive(false);        
    }
        
    private void DestroySprite()
    {
        if(this.imgScreenshot.sprite != null)
        {
            if(this.imgScreenshot.sprite.texture != null)
                GameObject.Destroy(this.imgScreenshot.sprite.texture); 
            GameObject.Destroy(this.imgScreenshot.sprite); 
        }
    }

    public void LoadClicked()
    {
        this.OnLoad(); 
    }

    public void SaveClicked()
    {
        this.OnSave(); 
    }

    public void DeleteClicked()
    {
        this.OnDelete(); 
    }

    protected void OnLoad()
    {
        Action<SaveMetadata> h = this.Load;
        if (h != null)
            h(this.saveFile);
    }    

    protected void OnSave()
    {
        Action<SaveMetadata> h = this.Save;
        if (h != null)
            h(this.saveFile);
    }

    protected void OnDelete()
    {
        Action<SaveMetadata> h = this.Delete; 
        if(h != null)
            h(this.saveFile); 
    }

    public SaveMetadata SaveFile { get { return this.saveFile; } }
    public bool CanSave { get { return this.canSave; } set { this.canSave = value; } }
}
