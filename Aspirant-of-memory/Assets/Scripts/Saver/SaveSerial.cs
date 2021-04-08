using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveSerial : MonoBehaviour
{
    [SerializeField] private Mode startMode;

    private int level;
    private Mode mode;


    private BinaryFormatter binaryFormatter;
    private FileStream file;
    private SaveData data;

    public Mode Mode()
    {
        if (mode != null)
        {
            return mode;
        }
        else
        {
            return startMode;
        }
    }

    public void SaveLevel(int level)
    {
        CreateBinarFormate();
        ParametersChanger(level, Mode());
        Serializer();
    }
    public void SaveAll(int level, Mode mode)
    {
        CreateBinarFormate();
        ParametersChanger(level, mode);
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

            ParametersChanger(data.Level, data.Mode);

            Debug.Log("Game data loaded!");
        }
        else
        {
            ParametersChanger(0, startMode);
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

            ParametersChanger(0, startMode);

            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

    private void ParametersChanger(int level, Mode mode)
    {
        this.level = level;
        this.mode = mode;
    }
}
[Serializable]
class SaveData
{
    public int Level;
    public Mode Mode;
}
