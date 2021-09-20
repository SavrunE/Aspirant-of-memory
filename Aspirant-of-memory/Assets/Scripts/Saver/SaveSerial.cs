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
    public Mode Mode;
<<<<<<< HEAD
=======
    public LevelConfiguration activeLevelConfiguration;
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e
}

public class SaveSerial : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private Mode startMode;
=======
    [SerializeField] private Mode defoultStartMode;
    [SerializeField] private LevelConfiguration startLevelConfiguration;
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e

    private int level;
    private int points;
    private Mode mode;
<<<<<<< HEAD
=======
    private LevelConfiguration activeLevelConfiguration;
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e

    public int Level() => level;

    private BinaryFormatter binaryFormatter;
    private FileStream file;
    private SaveData data;

    public Mode Mode()
    {
        if (mode != null)
        {
            return mode;
        }
        if (data.Mode != null)
        {
            return data.Mode;
        }
        else
        {
<<<<<<< HEAD
            return startMode;
=======
            Debug.Log("In SaveSerial on load modeContainer == null");
            return defoultStartMode;
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
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e
        }
    }

    public void SaveLevel(int level)
    {
        CreateBinarFormate();
<<<<<<< HEAD
        ParametersChanger(level, points, Mode());
        Serializer();
    }
    public void SaveAll(int level, int points, Mode mode)
=======
        ParametersChanger(level, this.points, Mode(), ActiveLevelConfiguration());
        Serializer();
    }
    public void SaveAll(int level, int points, Mode mode, LevelConfiguration activeLevelConfiguration)
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e
    {
        CreateBinarFormate();
        ParametersChanger(level, points, mode);
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

            ParametersChanger(data.Level, data.Points, data.Mode);

            Debug.Log("Game data loaded!");
        }
        else
        {
<<<<<<< HEAD
            ParametersChanger(0, 0, startMode);
=======
            ParametersChanger(0, 0, defoultStartMode, startLevelConfiguration);
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e
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

<<<<<<< HEAD
            ParametersChanger(0, 0, startMode);
=======
            ParametersChanger(0, 0, defoultStartMode, startLevelConfiguration);
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e

            Debug.Log("Data reset complete!");
        }
        else
            Debug.LogError("No save data to delete.");
    }

<<<<<<< HEAD
    private void ParametersChanger(int level, int points, Mode mode)
=======
    private void ParametersChanger(int level, int points, Mode mode, LevelConfiguration activeLevelConfiguration)
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e
    {
        this.level = level;
        this.points = points;
        if (mode == null)
        {
<<<<<<< HEAD
            this.mode = startMode;
=======
            this.mode = defoultStartMode;
            Debug.Log(this.mode);
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e
        }
        else
        {
            this.mode = mode;
        }

        Debug.Log(this.level);
        Debug.Log(this.mode);
    }
}

