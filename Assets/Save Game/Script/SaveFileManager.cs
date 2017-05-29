using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using UnityEngine;

// manages save game files on disc. 
public class SaveFileManager
{
    private string filePathBase = Path.Combine(Application.persistentDataPath, "save{0}.txt");
    private string screenShotBase = Path.Combine(Application.persistentDataPath, "saveScreen{0}.png");

    public SaveFile Load(int index)
    {
        string targetFile = string.Format(this.filePathBase, index);
        return this.LoadFile(targetFile);
    }

    public void Save(SaveFile save, int index)
    {
        string targetFile = string.Format(this.filePathBase, index);        
        using (FileStream fs = new FileStream(targetFile, FileMode.Create, FileAccess.Write))
        {
            XmlSerializer xs = new XmlSerializer(typeof(SaveFile));
            xs.Serialize(fs, save);          
        }
    }

    private SaveFile LoadFile(string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
        {
            XmlSerializer xs = new XmlSerializer(typeof(SaveFile));
            return xs.Deserialize(fs) as SaveFile;
        }
    }    

    public List<SaveFile> GetAllSaves()
    {
        List<SaveFile> result = new List<SaveFile>();
        string[] files = Directory.GetFiles(Application.persistentDataPath, "save*", SearchOption.TopDirectoryOnly);
        if (files != null && files.Length > 0)
            foreach (string file in files)
                result.Add(this.LoadFile(file));

        return result;
    }

    public bool HasSaveFiles()
    {
        string[] files = Directory.GetFiles(Application.persistentDataPath, "save*", SearchOption.TopDirectoryOnly);
        return files != null && files.Length > 0;
    }

    public bool DeleteFile(int index)
    {
        string targetFile = string.Format(this.filePathBase, index); 
        if(File.Exists(targetFile))
        {
            File.Delete(targetFile);
            targetFile = string.Format(this.screenShotBase, index);
            if (File.Exists(targetFile))
                File.Delete(targetFile);
            return true;
        }
        return false; 
    }
}
