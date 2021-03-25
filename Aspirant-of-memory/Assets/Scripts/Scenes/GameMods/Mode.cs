using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using IJunior.TypedScenes;

public abstract class Mode : MonoBehaviour
{
    protected static int levelNumber;

    protected ActiveLevelConfiguration activeLevelConfigurationSettings;
    public int CurrentPoints { get; private set; }
    public int PointsForWinLevel { get; private set; }
    public int MaxModePoints { get; private set; }

    protected int[] levelParameters;
    protected int SettingsCount => activeLevelConfigurationSettings.TakeParameters().Count;
    public int LevelNumber => levelNumber;
    public Action<int> OnLevelChanged;

    public abstract void ChangeConfigurationsValues();

    private void Start()
    {
        levelParameters = new int[SettingsCount];
    }

    public void ChangeActiveLevelConfiguration(ActiveLevelConfiguration activeLevelConfigurationSettings)
    {
        this.activeLevelConfigurationSettings = activeLevelConfigurationSettings;
    }
    public void NextLevelLoad()
    {
        //Debug.Log(LevelNumber);
        OnLevelChanged?.Invoke(LevelNumber);
        ChangeConfigurationsValues();
        DefaultLevel.Load(activeLevelConfigurationSettings);
    }

    public void RestartLevel()
    {
        OnLevelChanged?.Invoke(LevelNumber);
        DefaultLevel.Load(activeLevelConfigurationSettings);
    }

    public void RefundLevelSettings()
    {
        ResetLevelNumber();
        activeLevelConfigurationSettings.RefundLevelSettings();
        DefaultLevel.Load(activeLevelConfigurationSettings);
    }

    public void ResetLevelNumber()
    {
        levelNumber = 0;
    }
}
