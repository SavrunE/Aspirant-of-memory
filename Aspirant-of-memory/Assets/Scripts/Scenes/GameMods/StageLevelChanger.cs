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

    protected ActiveLevelConfiguration activeLevelConfiguration;
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
        this.activeLevelConfiguration = activeLevelConfiguration;
    }

    public void ChangeLevelConfigurationParametes(int[] parameters)
    {
        this.startLevelConfigurationParameters = parameters;
    }

    public void LoadProgressStageLevel()
    {
        for (int i = 0; i < activeLevelConfiguration.StageLevelNumberInfo(); i++)
        {
            ChangeConfigurationsValuesOnWin();
        }
    }

    public void ChangeConfigurationsValuesOnWin() 
    {
        UpdatePoints(GetComponent<Points>().PointsCount);
        SaveSerial.SaveAll(activeLevelConfiguration.MaxOpenLevel, CurrentPoints, activeLevelConfiguration.Parameters);
    }

    public void StageLevelComplete()
    {
        if (activeLevelConfiguration.StageLevelNumberInfo() >= maxStageLevel)
        {
            if (activeLevelConfiguration.CurrentLevel == activeLevelConfiguration.MaxOpenLevel)
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
        SaveSerial.SaveAll(activeLevelConfiguration.MaxOpenLevel + 1, CurrentPoints, activeLevelConfiguration.Parameters);
    }

    public void NextStageLevelLoad()
    {
        activeLevelConfiguration.IncreaseStageLevelNumber();
        OnStageLevelChanged?.Invoke(activeLevelConfiguration.StageLevelNumberInfo());
        ChangeConfigurationsValuesOnWin();
        Debug.Log("Win and increased stage level");
        DefaultLevel.Load(activeLevelConfiguration);
    }

    public void RestartLevel()
    {
        DefaultLevel.Load(activeLevelConfiguration);
    }

    public void RefundLevelSettings()
    {
        ResetLevel();
        activeLevelConfiguration.RefundLevelSettings(startLevelConfigurationParameters);
        DefaultLevel.Load(activeLevelConfiguration);
    }

    public void ResetLevel()
    {
        activeLevelConfiguration.RefundLevelSettings(startLevelConfigurationParameters);
        activeLevelConfiguration.ResetStageLevelNumber();
    }

    public void UpdatePoints(int points)
    {
        CurrentPoints = points;
    }
}
