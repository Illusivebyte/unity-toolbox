using System;
using System.IO;
using UnityEngine;

public class DataSaver
{
    public static void SaveData<T>(string fileName, T data)
    {
        try
        {
            string json = JsonUtility.ToJson(data);
            Debug.Log(json);
            File.WriteAllText(Application.persistentDataPath + "/" + fileName, json);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to save data to {fileName}: {ex.Message}");
        }
    }

    public static T LoadData<T>(string fileName)
    {
        try
        {
            if (!File.Exists(fileName)) return default;
            string json = File.ReadAllText(Application.persistentDataPath + "/" + fileName);
            Debug.Log(json);
            return JsonUtility.FromJson<T>(json);
        }
        catch (Exception ex)
        {
            Debug.LogError($"Failed to load or deserialize data from {fileName}: {ex.Message}");
            return default;
        }
    }
}
