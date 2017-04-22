using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

// This is for more detailed information about the save game. 
public class PlayerSaveData
{    
    public Vector3 Position { get; set; }
    public Vector3 Forward { get; set; }
    public List<string> Spells { get; set; }
    public List<string> Inventory { get; set; }    
}
