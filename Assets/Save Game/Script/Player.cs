using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

// statically accessible player object. 
public class Player : MonoBehaviour
{
    #region Singleton
    private static Player instance;
    public static Player Instance { get { return instance; } }

    void Awake()
    {
        instance = this;
    }
    #endregion

    void Start()
    {
        this.InteractionController = this.GetComponent<PlayerInteractionController>();
        this.MovementController = this.GetComponent<SimpleFPSController>();
        
        // default this to now so that we have the correct play time on the first save. 
        this.LoadedSaveData = new SaveMetadata { SaveTime = DateTime.Now };
        this.Inventory = new List<string>();
        this.Spells = new List<string>();

        this.HP = this.MaxHP = 20;
        this.Level = 1;
        this.CharacterName = "No Name";
    }

    public PlayerInteractionController InteractionController { get; private set; }
    public SimpleFPSController MovementController { get; set; }

    // keeping a ref to track time played. 
    public SaveMetadata LoadedSaveData { get; set; }

    // some generic RPG character metadata to save / display on save file.
    public string CharacterName { get; set; }
    public int Level { get; set; }
    public int HP { get; set; }
    public int MaxHP { get; set; }

    // some more in depth information to save that isn't part of the metadata. 
    public List<string> Inventory { get; set; }
    public List<string> Spells { get; set; }

}
