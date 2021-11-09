using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class SaveData
{
    public int PlayersMaxOpenLevel;
    public int PlayersCurrentPoints;
    public ActiveLevelConfiguration activeLevelConfiguration;
}

public class SaveSerial : MonoBehaviour
{
    private int playersMaxOpenLevel;
    private int playersCurrentPoints;
    
    [SerializeField] private ActiveLevelConfiguration activeLevelConfiguration;

    public int Level() => playersMaxOpenLevel;

    private BinaryFormatter binaryFormatter;
    private FileStream file;
    private SaveData data;

    public void SaveLevel(int level)
    {
        CreateBinarFormate();
        ParametersChanger(level);
        Serializer();
    }
  
    public void SaveAll(int level, int points)
    {
        CreateBinarFormate();
        ParametersChanger(level, points);
        Serializer();
    }

    private void CreateBinarFormate()
    {
        binaryFormatter = new BinaryFormatter();
        file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        data = new SaveData();
    }

    private void Serializer()
    {
        binaryFormatter.Serialize(file, data);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            binaryFormatter = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath
             + "/MySaveData.dat", FileMode.Open);
            data = (SaveData)binaryFormatter.Deserialize(file);
            file.Close();

            ParametersChanger(data.PlayersMaxOpenLevel, data.PlayersCurrentPoints);

            Debug.Log("Game data loaded!");
        }
        else
        {
            ParametersChanger(0, 0);
            Debug.Log("There is no save data! Taked reset.");
        }
    }
    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/MySaveData.dat");

            ParametersChanger(0, 0);

            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    private void ParametersChanger(int level)
    {
        this.playersMaxOpenLevel = level;

        activeLevelConfiguration.ChangeMaxOpenLevel(data.PlayersMaxOpenLevel);
    }

    private void ParametersChanger(int level, int points)
    {
        this.playersMaxOpenLevel = level;
        this.playersCurrentPoints = points;

        activeLevelConfiguration.ChangeMaxOpenLevel(data.PlayersMaxOpenLevel);
    }
}

