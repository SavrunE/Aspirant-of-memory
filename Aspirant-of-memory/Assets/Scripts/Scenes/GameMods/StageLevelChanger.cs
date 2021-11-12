using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using IJunior.TypedScenes;

public class StageLevelChanger : MonoBehaviour
{
    public SaveSerial SaveSerial;
    [SerializeField] protected int pointsAfterWinStageLevel = 10;
    [SerializeField] protected int maxStageLevel = 5;
    [SerializeField] protected int pointsFromWin = 50;

    public int PointsAfterWinStageLevel => pointsAfterWinStageLevel;

    protected ActiveLevelConfiguration activeLevelConfigurationSettings;
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
        SaveSerial = new SaveSerial();
        levelParameters = new int[SettingsCount];
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
        SaveSerial.SaveAll(activeLevelConfigurationSettings.StageLevelNumber, CurrentPoints);
        
        //throw new NotImplementedException();
    }

    public void StageLevelComplete()
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
        activeLevelConfigurationSettings.RefundLevelSettings(startLevelConfigurationParameters);
        DefaultLevel.Load(activeLevelConfigurationSettings);
    }

    public void ResetLevel()
    {
        activeLevelConfigurationSettings.RefundLevelSettings(startLevelConfigurationParameters);
        activeLevelConfigurationSettings.RefundStageLevelNumber();
    }

    public void UpdatePoints(int points)
    {
        CurrentPoints = points;
    }
}
