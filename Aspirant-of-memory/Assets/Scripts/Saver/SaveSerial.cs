using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

[Serializable]
class SaveData
{
    public int Level;
    public int Points;
    public ModeContainer Mode;
    public LevelConfiguration activeLevelConfiguration;
}

public class SaveSerial : MonoBehaviour
{
    [SerializeField] private ModeContainer modeContainer;
    [SerializeField] private LevelConfiguration startLevelConfiguration;

    private int level;
    private int points;
    private ModeContainer mode;
    private LevelConfiguration activeLevelConfiguration;

    private BinaryFormatter binaryFormatter;
    private FileStream file;
    private SaveData data;

    public ModeContainer Mode()
    {
        if (mode != null)
        {
            return mode;
        }
        else
        {
            Debug.Log("In SaveSerial on load modeContainer == null");
            return modeContainer;
        }
    }

    public LevelConfiguration ActiveLevelConfiguration()
    {
        if (activeLevelConfiguration != null)
        {
            return activeLevelConfiguration;
        }
        else
        {
            Debug.Log("In SaveSerial on load activeLevelConfiguration == null");
            return startLevelConfiguration;
        }
    }

    public void SaveLevel(int level)
    {
        CreateBinarFormate();
        ParametersChanger(level, points, Mode(), ActiveLevelConfiguration());
        Serializer();
    }
    public void SaveAll(int level, int points, ModeContainer mode, LevelConfiguration activeLevelConfiguration)
    {
        CreateBinarFormate();
        ParametersChanger(level, points, mode, activeLevelConfiguration);
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

            ParametersChanger(data.Level, data.Points, data.Mode, data.activeLevelConfiguration);

            Debug.Log("Game data loaded!");
        }
        else
        {
            ParametersChanger(0, 0, modeContainer, startLevelConfiguration);
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

            ParametersChanger(0, 0, modeContainer, startLevelConfiguration);

            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    private void ParametersChanger(int level, int points, ModeContainer mode, LevelConfiguration activeLevelConfiguration)
    {
        this.level = level;
        this.points = points;
        if (mode == null)
        {
            this.mode = modeContainer;
        }
        else
        {
            this.mode = mode;
        }
        this.activeLevelConfiguration = activeLevelConfiguration;
    }
}

