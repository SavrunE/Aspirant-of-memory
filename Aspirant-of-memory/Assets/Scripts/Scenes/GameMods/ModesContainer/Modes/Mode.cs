using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using IJunior.TypedScenes;

public abstract class Mode : MonoBehaviour
{
    protected static int levelNumber;
    [SerializeField] protected int maxLevel = 5;
    [SerializeField] protected int pointsFromWin = 14;
    public int PointsFromWin => pointsFromWin;

    [SerializeField] protected LevelConfiguration levelConfiguration;
    public int CurrentPoints { get; private set; }
    public int PointsForWinLevel { get; private set; }
    public int MaxModePoints { get; private set; }

    protected int[] levelParameters;
    protected int SettingsCount => levelConfiguration.TakeParameters().Count;
    public int LevelNumber => levelNumber;
    public Action<int> OnLevelChanged;

    public abstract void ChangeConfigurationsValuesOnWin();
    public void ChangeConfigurationsValues() 
    {
        levelNumber++;
        ChangeConfigurationsValuesOnWin();
    }

    private void Awake()
    {
        Debug.Log(levelConfiguration);
        levelParameters = new int[SettingsCount];
    }
    public void IncreaseLevel(int number)
    {
        for (int i = 0; i < number; i++)
        {
            ChangeConfigurationsValuesOnWin();
        }
    }

    public bool ModeCompleted()
    {
        if (levelNumber >= maxLevel)
        {
            return true;
        }
        else
        {
            NextLevelLoad();
            return false;
        }
    }

    public void NextLevelLoad()
    {
        OnLevelChanged?.Invoke(LevelNumber);
        ChangeConfigurationsValues();
        DefaultLevel.Load(levelConfiguration);
    }

    public void RestartLevel()
    {
        OnLevelChanged?.Invoke(LevelNumber);
        DefaultLevel.Load(levelConfiguration);
    }

    public void RefundLevelSettings()
    {
        ResetLevel();
        levelConfiguration.RefundLevelSettings(levelConfiguration);
        DefaultLevel.Load(levelConfiguration);
    }

    public void ResetLevel()
    {
        levelConfiguration.RefundLevelSettings(levelConfiguration);
        levelNumber = 0;
    }
}
