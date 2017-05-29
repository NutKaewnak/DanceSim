using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Linq;
using UnityEngine.UI;
using System.IO;

// screen controller for the save game screen. This has the list of saves available as well as the detail view of the save file 
// selected from the list. 
public class SaveGameController : MonoBehaviour
{ 
    [SerializeField]
    private ListPanel saveListPanel; 
    [SerializeField]
    private SaveDetailController detailController;
    [SerializeField]
    private GameObject newSave; 
    private SaveFileManager saveManager; 
    private SaveIndexManager saveIndexManager;     
    
    void Start()
    {
        if (this.detailController == null) Debug.LogError("DetailController not attached");           
    }

    void OnDestroy()
    {
        this.UnsubscribeToDetailControllerEvents();
    }

    public void SubscribeToDetailControllerEvents()
    {
        if (this.detailController != null)
        {
            this.detailController.Save += DetailController_Save;
            this.detailController.Load += DetailController_Load;
            this.detailController.Delete += DetailController_Delete;
            this.saveListPanel.ItemSelected += SaveListPanel_ItemSelected;
        }
    }

    public void UnsubscribeToDetailControllerEvents()
    {
        if (this.detailController != null)
        {
            this.detailController.Save -= DetailController_Save;
            this.detailController.Load -= DetailController_Load;
            this.detailController.Delete -= DetailController_Delete;
            this.saveListPanel.ItemSelected -= SaveListPanel_ItemSelected;
        }
    }

    void OnEnable()
    {
        this.SubscribeToDetailControllerEvents();
        if(this.saveManager == null)
            this.saveManager = new SaveFileManager();         
 
        if(this.saveIndexManager == null)
        {
            this.saveIndexManager = new SaveIndexManager(); 
            this.saveIndexManager.LoadMetadata();
        }

        this.UpdateSaveList();
        this.saveListPanel.SelectFirstItem();
    
    }    
    
    void OnDisable()
    {
        UnsubscribeToDetailControllerEvents();
        this.saveListPanel.ClearItems();        
        this.detailController.Clear();
    }

    private void UpdateSaveList()
    {
        IEnumerable<SaveMetadata> metadata = this.saveIndexManager.GetItems(); 
        if(metadata != null)
        {
            foreach(SaveMetadata meta in metadata)
            {         
                GameObject go = this.saveListPanel.CreateItem();                       
                SaveListItemController slic = go.GetComponent<SaveListItemController>(); 
                if(slic != null)                
                    slic.SetData(meta);                                                    
            }
        }        
    }

    private void SaveListPanel_ItemSelected(GameObject obj)
    {
        SaveListItemController ctrl = obj.GetComponent<SaveListItemController>(); 
        if(ctrl != null)        
            this.detailController.SetData(ctrl.SaveFile);                 
    }
     
    private SaveFile CreateFileFromCurrent()
    {
        SaveFile sf = new SaveFile(); 
        sf.PlayerData = new PlayerSaveData
        {
            Forward = Player.Instance.transform.forward,
            Position = Player.Instance.transform.position,
            Inventory = Player.Instance.Inventory,
            Spells = Player.Instance.Spells            
        };            
          
        return sf; 
    }

    // creating a new save file. 
    private SaveMetadata CreateMetadataFromCurrent()
    {        
        return new SaveMetadata
        {
            Location = this.AccessedSavePoint.LocationName,
            NumberOfSaves = 1,
            TimePlayed = DateTime.Now - Player.Instance.LoadedSaveData.SaveTime,
            SaveTime = DateTime.Now,            
            PlayerHP = Player.Instance.HP,
            PlayerLevel = Player.Instance.Level,
            PlayerMaxHP = Player.Instance.MaxHP,
            PlayerName = Player.Instance.CharacterName
        };        
    }

    // updating the metadata when saving from a loaded save. 
    private void UpdateMetadataFromCurrent(SaveMetadata meta)
    {
        meta.Location = this.AccessedSavePoint.LocationName;
        meta.TimePlayed += DateTime.Now - Player.Instance.LoadedSaveData.SaveTime;
        meta.SaveTime = DateTime.Now;
        meta.PlayerHP = Player.Instance.HP;
        meta.PlayerLevel = Player.Instance.Level;
        meta.PlayerMaxHP = Player.Instance.MaxHP;
        meta.PlayerName = Player.Instance.CharacterName;

    }

    private void LoadFromSave(SaveMetadata meta)
    {        
        SaveFile saveFile = this.saveManager.Load(meta.Index);
        Player.Instance.LoadedSaveData = meta;        
        Player.Instance.MovementController.SetForward(saveFile.PlayerData.Forward);         
        Player.Instance.transform.position = saveFile.PlayerData.Position;
        Player.Instance.HP = meta.PlayerHP;
        Player.Instance.Level = meta.PlayerLevel;
        Player.Instance.MaxHP = meta.PlayerMaxHP;
        Player.Instance.CharacterName = meta.PlayerName;

        if(saveFile.PlayerData.Inventory != null)
            Player.Instance.Inventory = saveFile.PlayerData.Inventory;
        if(saveFile.PlayerData.Spells != null)
            Player.Instance.Inventory = saveFile.PlayerData.Spells;               
    }

    public void OnCancel()
    {
        ScreenManager.Instance.CloseSaveScreen();
    }

    public void OnNewSaveFile()
    {
        SaveFile saveFile = this.CreateFileFromCurrent();      
        SaveMetadata saveMeta = this.CreateMetadataFromCurrent();
        this.saveIndexManager.AddOrReplaceMetadata(saveMeta);   
        this.saveManager.Save(saveFile, saveMeta.Index); 
        this.saveIndexManager.SaveMetadata();
        this.RenameScreenshot(saveMeta.Index);
        ScreenManager.Instance.CloseSaveScreen();
    }

    private void DetailController_Load(SaveMetadata saveMeta)
    {                
        this.LoadFromSave(saveMeta);        
        ScreenManager.Instance.CloseSaveScreen();
        HUDManager.Instance.ShowNotification("Game Loaded");    
    }

    private void DetailController_Save(SaveMetadata saveMeta)
    {        
        SaveFile saveFile = CreateFileFromCurrent();        
        this.saveManager.Save(saveFile, saveMeta.Index);   
        this.UpdateMetadataFromCurrent(saveMeta);
        saveMeta.NumberOfSaves++;
        this.saveIndexManager.SaveMetadata();
        this.RenameScreenshot(saveMeta.Index);
        ScreenManager.Instance.CloseSaveScreen();
        HUDManager.Instance.ShowNotification("Game Saved");    
    }

    private void DetailController_Delete(SaveMetadata saveMeta)
    {
        if(this.saveManager.DeleteFile(saveMeta.Index))
        {
            this.saveIndexManager.Delete(saveMeta);                         
            foreach(Transform t in this.saveListPanel.transform)
            {
                SaveListItemController slic = t.GetComponent<SaveListItemController>(); 
                if(slic != null && slic.SaveFile == saveMeta)
                {
                    GameObject.Destroy(t.gameObject);                     
                    break;
                }
            }
            this.detailController.Clear();            
        }
        this.StartCoroutine(this.WaitAndSelectFirst());        
    }    

    // make sure ui updates have occurred before updating the selection. 
    public IEnumerator WaitAndSelectFirst()
    {
        yield return new WaitForEndOfFrame();
        this.saveListPanel.SelectFirstItem();
    }

    private void RenameScreenshot(int index)
    {
        string screenshot = Path.Combine(Application.persistentDataPath, "tmpScreenshot.png"); 
        if(File.Exists(screenshot))
        {
            string newScreenshot = Path.Combine(Application.persistentDataPath, string.Format("saveScreen{0}.png", index));
            if (File.Exists(newScreenshot))
                File.Delete(newScreenshot);
            File.Move(screenshot, newScreenshot); 
        }
    }

    public bool CanSave
    {
        get { return this.detailController.CanSave; }
        set
        {
            this.detailController.CanSave = value;
            this.newSave.SetActive(value);
        }
    }

    public SavePoint AccessedSavePoint { get; set; }
}
