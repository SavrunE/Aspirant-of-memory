using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using IJunior.TypedScenes;

public class StageLevelChanger : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    public SaveSerial SaveSerial;
    [SerializeField] protected int pointsAfterWinStageLevel = 10;
    [SerializeField] protected int maxStageLevel = 5;
    [SerializeField] protected int pointsFromWin = 50;

    public int PointsAfterWinStageLevel => pointsAfterWinStageLevel;

    protected ActiveLevelConfiguration activeLevelConfigurationSettings;
    protected LevelConfiguration levelConfiguration;
    protected int[] startLevelConfigurationParameters;
    public int CurrentPoints { get; private set; }
    public int PointsForWinLevel { get; private set; }
    public int MaxModePoints { get; private set; }

    protected int[] levelParameters;
    protected int SettingsCount => startLevelConfigurationParameters.Length;
    public Action<int> OnStageLevelChanged;
    public Action<StageLevelChanger> OnModeChanged;

    private void Awake()
    {
        levelParameters = new int[SettingsCount];
    }

    public void OnSceneLoaded(LevelConfiguration argument)
    {
        levelConfiguration = argument;
    }

    public void ChangeActiveLevelConfiguration(ActiveLevelConfiguration activeLevelConfiguration)
    {
        this.activeLevelConfigurationSettings = activeLevelConfiguration;
    }

    public void ChangeLevelConfigurationParametes(int[] parameters)
    {
        this.startLevelConfigurationParameters = parameters;
    }

    public void LoadProgressStageLevel()
    {
        for (int i = 0; i < activeLevelConfigurationSettings.StageLevelNumber; i++)
        {
            ChangeConfigurationsValuesOnWin();
        }
    }

    public void ChangeConfigurationsValuesOnWin() 
    {
        UpdatePoints(GetComponent<Points>().PointsCount);
        SaveSerial.SaveAll(activeLevelConfigurationSettings.MaxOpenLevel, CurrentPoints, activeLevelConfigurationSettings.Parameters);
    }

    public void StageLevelComplete()
    {
        if (activeLevelConfigurationSettings.StageLevelNumber >= maxStageLevel)
        {
            if (activeLevelConfigurationSettings.CurrentLevel == activeLevelConfigurationSettings.MaxOpenLevel)
            {
                IncreaseMaxOpenLevel();
            }
            Debug.Log("Win and loaded start window");
            StartWindow.Load();
        }
        else
        {
            NextStageLevelLoad();
        }
    }

    private void IncreaseMaxOpenLevel()
    {
        SaveSerial.SaveAll(activeLevelConfigurationSettings.MaxOpenLevel + 1, CurrentPoints, activeLevelConfigurationSettings.Parameters);
    }

    public void NextStageLevelLoad()
    {
        activeLevelConfigurationSettings.IncreaseStageLevelNumber();
        OnStageLevelChanged?.Invoke(activeLevelConfigurationSettings.StageLevelNumber);
        ChangeConfigurationsValuesOnWin();
        Debug.Log("Win and increased stage level");
        DefaultLevel.Load(levelConfiguration);
    }

    public void RestartLevel()
    {
        DefaultLevel.Load(levelConfiguration);
    }

    public void RefundLevelSettings()
    {
        ResetLevel();
        activeLevelConfigurationSettings.RefundLevelSettings(startLevelConfigurationParameters);
        DefaultLevel.Load(activeLevelConfigurationSettings);
    }

    public void ResetLevel()
    {
        activeLevelConfigurationSettings.RefundLevelSettings(startLevelConfigurationParameters);
        activeLevelConfigurationSettings.ResetStageLevelNumber();
    }

    public void UpdatePoints(int points)
    {
        CurrentPoints = points;
    }
}
