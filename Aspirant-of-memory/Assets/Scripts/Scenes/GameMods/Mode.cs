using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using IJunior.TypedScenes;

public abstract class Mode : MonoBehaviour
{
    public SaveSerial SaveSerial;
    [SerializeField] protected int maxStageLevel = 5;
    [SerializeField] protected int pointsFromWin = 14;
    public int PointsFromWin => pointsFromWin;

    [SerializeField] protected ActiveLevelConfiguration activeLevelConfigurationSettings;
    [SerializeField] protected LevelConfiguration startLevelConfiguration;
    public int CurrentPoints { get; private set; }
    public int PointsForWinLevel { get; private set; }
    public int MaxModePoints { get; private set; }

    protected int[] levelParameters;
    protected int SettingsCount => startLevelConfiguration.TakeParameters().Count;
    public Action<int> OnStageLevelChanged;
    public Action<Mode> OnModeChanged;

    public abstract void ChangeConfigurationsValuesOnWin();

    private void Awake()
    {
        levelParameters = new int[SettingsCount];
    }

    public void LoadProgress()
    {
        for (int i = 0; i < activeLevelConfigurationSettings.StageLevelNumber; i++)
        {
            ChangeConfigurationsValuesOnWin();
        }
    }

    public void StageLevelComplete(ModesContainer modsContainer)
    {
        if (activeLevelConfigurationSettings.StageLevelNumber >= maxStageLevel)
        {
            if (activeLevelConfigurationSettings.CurrentLevel == activeLevelConfigurationSettings.MaxOpenLevel)
            {
                SaveSerial.SaveLevel(activeLevelConfigurationSettings.MaxOpenLevel + 1);
            }
            StartWindow.Load();
        }
        else
        {
            NextStageLevelLoad();
        }
    }

    public void NextStageLevelLoad()
    {
        activeLevelConfigurationSettings.IncreaseStageLevelNumber();
        OnStageLevelChanged?.Invoke(activeLevelConfigurationSettings.StageLevelNumber);
        ChangeConfigurationsValuesOnWin();
        DefaultLevel.Load(activeLevelConfigurationSettings);
    }

    public void RestartLevel()
    {
        OnStageLevelChanged?.Invoke(activeLevelConfigurationSettings.StageLevelNumber);
        DefaultLevel.Load(activeLevelConfigurationSettings);
    }

    public void RefundLevelSettings()
    {
        ResetLevel();
        activeLevelConfigurationSettings.RefundLevelSettings(startLevelConfiguration);
        DefaultLevel.Load(activeLevelConfigurationSettings);
    }

    public void ResetLevel()
    {
        activeLevelConfigurationSettings.RefundLevelSettings(startLevelConfiguration);
        activeLevelConfigurationSettings.RefundStageLevelNumber();
    }
}
