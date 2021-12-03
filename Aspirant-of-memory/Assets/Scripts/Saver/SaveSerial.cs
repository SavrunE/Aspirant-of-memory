using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class SaveData
{
    public int PlayersCurrentPoints;
    public int[] Parameters;
    public int[] OpenLevels;
}

[RequireComponent(typeof(ConfigurationChanger))]
public class SaveSerial : MonoBehaviour
{
    public int PiontsCurrentValue { get; private set; }
    private int[] parameters;
    private List<int> openLevels;

    private BinaryFormatter binaryFormatter;
    private FileStream file;
    private SaveData data;

    public event Action<int> OnMaxOpenLevelChanged;

    public List<int> OpenLevels() => openLevels;

    public void SaveParameters(int points, int[] parameters)
    {
        ParametersChanger(points, parameters);
    } 

    public void SaveParameters(int points, int[] parameters, int level)
    {
        ParametersChanger(points, parameters, level);
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

            SaveParameters(data.PlayersCurrentPoints, data.Parameters);
            LoadOpenLevels();

            Debug.Log("Game data loaded!");
        }
        else
        {
            ParametersChanger(0, null);
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

            SaveParameters(0, null);
            ResetOpenLevels();

            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    private void ResetOpenLevels()
    {
        openLevels = new List<int>(1);
        openLevels.Add(1);
    }

    private void ParametersChanger(int points, int[] parameters)
    {
        this.PiontsCurrentValue = points;
        this.parameters = parameters;

        ChangeData(points, parameters);
    }

    private void ParametersChanger(int points, int[] parameters, int level)
    {
        this.PiontsCurrentValue = points;
        this.parameters = parameters;

        ChangeData(points, parameters, level);
    }

    public void ChangeData(int playersCurrentPoints, int[] parameters)
    {
        ChangeData(playersCurrentPoints, parameters, 0);
    }
    public void ChangeData(int playersCurrentPoints, int[] parameters, int level)
    {
        CreateBinarySettings();
        
        data.PlayersCurrentPoints = playersCurrentPoints;
        data.Parameters = parameters;

        OpenLevel(level);


        SerializeAndCloseFile();
        Debug.Log("Game data changed!");
    }
    public void OpenLevel(int level)
    {
        if (openLevels == null)
        {
            openLevels = new List<int>(1);
            openLevels.Add(1);
            Debug.Log("openLevels was null");
        }
        if (level != 0)
        {
            openLevels.Add(level);
            Debug.Log($"Open level {openLevels.IndexOf(level)} is saved");
            SaveOpenLevel();
            OnMaxOpenLevelChanged(level);
        }
        else
        {
            SaveOpenLevel();
        }
       
    }

    private void SaveOpenLevel()
    {
        data.OpenLevels = new int[openLevels.Count];
        int i = 0;
        foreach (var openLevel in openLevels)
        {
            data.OpenLevels[i] = openLevel;
            i++;
        }
    }

    private void CreateBinarySettings()
    {
        binaryFormatter = new BinaryFormatter();
        file = File.Create(Application.persistentDataPath
          + "/MySaveData.dat");
        data = new SaveData();
    }

    private void SerializeAndCloseFile()
    {
        binaryFormatter.Serialize(file, data);
        file.Close();
    }

    private void LoadOpenLevels()
    {
        this.openLevels = new List<int>(data.OpenLevels.Length);
        foreach (var openLevel in data.OpenLevels)
        {
            openLevels.Add(openLevel);
            Debug.Log(openLevel);
        }
    }
}