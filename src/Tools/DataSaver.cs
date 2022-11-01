using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class DataSaver
{

    public static void SaveData(string filename, object data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + filename);
        bf.Serialize(file, data);
        file.Close();
    }

    public static object LoadData(string fileName)
    {
        if(File.Exists(Application.persistentDataPath + "/" + fileName))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + fileName, FileMode.Open);
            object o = bf.Deserialize(file);
            file.Close();
            return o;
        }
        else
        {
            return null;
        }
    }
}
