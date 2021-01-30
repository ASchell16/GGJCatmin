using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class SaveGameData
{
    public Dictionary<string,float> AudioSaves = new Dictionary<string, float>();
    public Dictionary<string,int> VideoSaves = new Dictionary<string, int>();
    public Dictionary<string,int> LevelSaves = new Dictionary<string, int>();
    public Dictionary<string,float> BestTimeSaves = new Dictionary<string, float>();
    public Dictionary<string, int> OtherIntSaves = new Dictionary<string, int>();
}

public static class SaveLoadFile
{
    private const string FILENAME = "/SteamCloud_LightWave.sav";

    public static void Save(SaveGameData steamCloudPrefs)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + FILENAME, FileMode.Create);

        bf.Serialize(stream, steamCloudPrefs);
        stream.Close();
    }

    public static SaveGameData Load()
    {
        if(File.Exists(Application.persistentDataPath + FILENAME))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + FILENAME, FileMode.Open);

            SaveGameData data = bf.Deserialize(stream) as SaveGameData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("File not found.");
            return null;
        }
    }
}