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
    private List<int> openLevels;

    private BinaryFormatter binaryFormatter;
    private FileStream file;
    private SaveData data;

    public event Action<int> OnMaxOpenLevelChanged;

    public List<int> OpenLevels() => openLevels;


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
        this.openLevels = new List<int>();
        foreach (var level in levels)
        {
            openLevels.Add(level);
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
        openLevels = new List<int>(1);
        openLevels.Add(1);
    }

    public void SaveParameters(int points)
    {
        this.PiontsCurrentValue = points;

        Debug.Log("Save points");
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
        Debug.Log("Game data changed!");
    }

    private void OpenLevel(int level)
    {
        if (openLevels == null)
        {
            openLevels = new List<int>(1);
            openLevels.Add(1);
            openLevels.Add(level);
            SaveOpenLevel();
            Debug.Log("openLevels was null");
        }
        if (level != 0)
        {
            openLevels.Add(level);
            Debug.Log($"Open level is saved by index {openLevels.IndexOf(level)}#");
            SaveOpenLevel();
            OnMaxOpenLevelChanged(level);
        }
    }

    private void SaveOpenLevel()
    {
        data.OpenLevels = new int[openLevels.Count];
        int i = 0;
        foreach (var openLevel in openLevels)
        {
            data.OpenLevels[i] = openLevel;
            Debug.Log(data.OpenLevels[i]);
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