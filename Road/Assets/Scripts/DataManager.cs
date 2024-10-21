using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager
{
    private readonly string _filePath;

    public DataManager()
    {
        _filePath = Application.streamingAssetsPath + "/SavedData.json";
    }

    public void SaveData(SavedData saveData)
    {
        string json = JsonUtility.ToJson(saveData);
        using (var writer = new StreamWriter(_filePath))
            writer.WriteLine(json);
    }

    public SavedData GetData()
    {
        Debug.Log("Начало загрузки");
        string json = "";
        using (var reader = new StreamReader(_filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                json += line;
            }
        }
        if(string.IsNullOrEmpty(json))
            return new SavedData();
        return JsonUtility.FromJson<SavedData>(json);
    }
}
