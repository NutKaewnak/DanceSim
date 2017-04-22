using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

// This is for information that the player will use to decide on which save to load. It gets displayed on the save game screen. 
public class SaveMetadata
{
    // the save index that this metadata represents. 
    public int Index { get; set; }
    // total game time played. 
    [XmlIgnore]
    public TimeSpan TimePlayed { get; set; }

    [XmlElement("TimePlayed")]
    public long TimePlayedTicks {  get { return TimePlayed.Ticks; } set { TimePlayed = new TimeSpan(value); } }

    // the time of the last save.
    public DateTime SaveTime { get; set; }    
    public int NumberOfSaves { get; set; }
    // save point identifying name. 
    public string Location { get; set; }    
    
    // some metadata about the player to show on the save screen. 
    public string PlayerName { get; set; }
    public int PlayerLevel { get; set; }
    public int PlayerHP { get; set; }
    public int PlayerMaxHP { get; set; }

}
