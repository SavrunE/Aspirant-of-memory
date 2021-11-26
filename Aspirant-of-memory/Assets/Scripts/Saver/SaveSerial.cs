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
    public int[] Parameters;
}

[RequireComponent(typeof(ConfigurationChanger))]
public class SaveSerial : MonoBehaviour
{
    public int PiontsCurrentValue { get; private set; }
    private int levelMaxOpenValue;
    private int[] parameters;

    public int Level() => levelMaxOpenValue;

    private BinaryFormatter binaryFormatter;
    private FileStream file;
    private SaveData data;

    public event Action<int> OnMaxOpenLevelChanged;

    public void SaveAll(int level, int points, int[] parameters)
    {
        ParametersChanger(level, points, parameters);
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

            ParametersChanger(data.PlayersMaxOpenLevel, data.PlayersCurrentPoints, data.Parameters);

            Debug.Log("Game data loaded!");
        }
        else
        {
            ParametersChanger(0, 0, null);
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

            SaveAll(0, 0, null);

            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    private void ParametersChanger(int level, int points, int[] parameters)
    {
        this.levelMaxOpenValue = level;
        this.PiontsCurrentValue = points;
        this.parameters = parameters;

        ChangeData(level, points, parameters);

        OnMaxOpenLevelChanged(levelMaxOpenValue);
    }

    public void ChangeData(int playersMaxOpenLevel, int playersCurrentPoints, int[] parameters)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        SaveData data = new SaveData();
        data.PlayersMaxOpenLevel = playersMaxOpenLevel;
        data.PlayersCurrentPoints = playersCurrentPoints;
        data.Parameters = parameters;
        bf.Serialize(file, data);
        file.Close();
        Debug.Log("Game data changed!");
    }
}