using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSimpleSerial : MonoBehaviour
{
    int intToSave = 0;
    float floatToSave = 0;
    [SerializeField] private ActiveLevelConfiguration activeLevelConfiguration;

    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveSimpleData data = new SaveSimpleData();
        data.savedInt = intToSave;
        data.savedFloat = floatToSave;
        data.activeLevelConfiguration = activeLevelConfiguration;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
              File.Open(Application.persistentDataPath
              + "/MySaveData.dat", FileMode.Open);
            SaveSimpleData data = (SaveSimpleData)bf.Deserialize(file);
            file.Close();
            intToSave = data.savedInt;
            floatToSave = data.savedFloat;
            activeLevelConfiguration = data.activeLevelConfiguration;
            Debug.Log("Game data loaded!");
        }
        else
            Debug.LogError("There is no save data!");
    }

    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/MySaveData.dat");
            intToSave = 0;
            floatToSave = 0.0f;
            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }
}

[Serializable]
class SaveSimpleData
{
    public int savedInt;
    public float savedFloat;
    public ActiveLevelConfiguration activeLevelConfiguration;
}