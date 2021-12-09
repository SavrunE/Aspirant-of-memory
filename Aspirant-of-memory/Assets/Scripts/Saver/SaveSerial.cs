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
    public int[] OpenLevels;
}

[RequireComponent(typeof(ConfigurationChanger))]
public class SaveSerial : MonoBehaviour
{
    public int PiontsCurrentValue { get; private set; }
    public List<int> OpenLevels { get; private set; }

    private BinaryFormatter binaryFormatter;
    private FileStream file;
    private SaveData data;

    public event Action<int> OnMaxOpenLevelChanged;

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

            LoadParameters(data.PlayersCurrentPoints, data.OpenLevels);

            Debug.Log("Game data loaded!");
        }
        else
        {
            int[] oneLevel = { 1 };
            LoadParameters(0, oneLevel);
            Debug.Log("There is no save data! Taked reset.");
        }
    }

    private void LoadParameters(int points, int[] openLevels)
    {
        PiontsCurrentValue = points;
        LoadOpenLevels(openLevels);
    }

    private void LoadOpenLevels(int[] levels)
    {
        this.OpenLevels = new List<int>();
        foreach (var level in levels)
        {
            OpenLevels.Add(level);
        }
    }

    public void ResetData()
    {
        if (File.Exists(Application.persistentDataPath
          + "/MySaveData.dat"))
        {
            File.Delete(Application.persistentDataPath
              + "/MySaveData.dat");

            SaveParameters(0, 1);
            ResetOpenLevels();

            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    private void ResetOpenLevels()
    {
        OpenLevels = new List<int>(1);
        OpenLevels.Add(1);
    }

    public void SaveParameters(int points)
    {
        this.PiontsCurrentValue = points;

        Debug.Log("Save points " + points);
        ChangeData(points);
    }

    public void SaveParameters(int points, int level)
    {
        this.PiontsCurrentValue = points;

        Debug.Log("Save points, level");
        ChangeData(points, level);
    }

    public void ChangeData(int points)
    {
        ChangeData(points, 0);
    }

    public void ChangeData(int points, int level)
    {
        CreateBinarySettings();
        
        data.PlayersCurrentPoints = points;

        OpenLevel(level);


        SerializeAndCloseFile();
    }

    private void OpenLevel(int level)
    {
        if (OpenLevels == null)
        {
            OpenLevels = new List<int>(1);
            OpenLevels.Add(1);
            OpenLevels.Add(level);
            SaveOpenLevel();
            Debug.Log("openLevels was null");
        }
        if (level != 0)
        {
            OpenLevels.Add(level);
            Debug.Log($"Open level is saved by index {OpenLevels.IndexOf(level)}#");
            SaveOpenLevel();
            OnMaxOpenLevelChanged(level);
        }
        if (level == 0)
        {
            SaveOpenLevel();
        }
    }

    private void SaveOpenLevel()
    {
        data.OpenLevels = new int[OpenLevels.Count];
        int i = 0;
        foreach (var openLevel in OpenLevels)
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
}