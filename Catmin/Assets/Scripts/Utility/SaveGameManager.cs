using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGameManager : Singleton<SaveGameManager>
{
    public SaveGameData SaveGame = new SaveGameData();

    private void Start()
    {
        if (SaveLoadFile.Load() != null)
        {
            SaveGame = SaveLoadFile.Load();
        }
    }

    private new void OnDestroy()
    {
        SaveLoadFile.Save(SaveGame);
        
        base.OnDestroy();
    }

}
