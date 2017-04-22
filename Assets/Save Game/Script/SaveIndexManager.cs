using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

// manages the file that as an index for save files. 
public class SaveIndexManager
{
    private string indexFile = Path.Combine(Application.persistentDataPath, "saveindex.txt");
    private List<SaveMetadata> metadata;        

    // throws exception if file is corrupt or inaccessible. 
    public void LoadMetadata()
    {
        try
        {
            if(File.Exists(this.indexFile))
            {
                using (FileStream fs = new FileStream(this.indexFile, FileMode.Open, FileAccess.Read))
                {
                    XmlSerializer xs = new XmlSerializer(typeof(List<SaveMetadata>));
                    this.metadata = xs.Deserialize(fs) as List<SaveMetadata>;
                }
            }
        }
        finally
        {
            if(this.metadata == null)        
                this.metadata = new List<SaveMetadata>();
        }
    }

    public void AddOrReplaceMetadata(SaveMetadata data)
    {
        if(data != null )            
        {            
            if(data.Index == 0)
            {
                if(this.metadata.Count > 0)
                    data.Index = this.metadata.Max(x => x.Index) + 1; 
                else data.Index = 1; 
                this.metadata.Add(data);
            }
            else
            {
                SaveMetadata existingdata = this.metadata.FirstOrDefault(x => x.Index == data.Index); 
                if(existingdata != null)
                {
                    existingdata.Location = data.Location; 
                    existingdata.NumberOfSaves = data.NumberOfSaves; 
                    existingdata.SaveTime = data.SaveTime; 
                    existingdata.TimePlayed = data.TimePlayed; 
                }
            }
        }
    }

    public void SaveMetadata()
    {
        using (FileStream fs = new FileStream(this.indexFile, FileMode.Create, FileAccess.Write))
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<SaveMetadata>));
            xs.Serialize(fs, this.metadata);
        }            
    }    

    public IEnumerable<SaveMetadata> GetItems()
    {
        return this.metadata; 
    }

    public void Delete(SaveMetadata meta)
    {
        if (this.metadata.Contains(meta))
        {
            this.metadata.Remove(meta);
            this.SaveMetadata();
        }
    }
}