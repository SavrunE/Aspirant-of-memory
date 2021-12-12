using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using IJunior.TypedScenes;

public class StageLevelChanger : MonoBehaviour
{
    protected SaveSerial saveSerial;
    protected ActiveLevelConfiguration activeLevelConfiguration;
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
        saveSerial = GetComponent<SaveSerial>();
    }

    public void ChangeActiveLevelConfiguration(ActiveLevelConfiguration activeLevelConfiguration)
    {
        this.activeLevelConfiguration = activeLevelConfiguration;
    }

    public void ChangeLevelConfigurationParametes(int[] parameters)
    {
        this.startLevelConfigurationParameters = parameters;
    }

    public void NextStageLevelLoad()
    {
        activeLevelConfiguration.IncreaseStageLevelNumber();
        OnStageLevelChanged?.Invoke(activeLevelConfiguration.StageLevelNumberInfo());
        ChangeConfigurationsValuesOnWinStageLevel();
        Debug.Log("Win and increased stage level");
        DefaultLevel.Load(activeLevelConfiguration);
    }

    public void ChangeConfigurationsValuesOnWinStageLevel()
    {
        UpdatePoints(GetComponent<Points>().PointsCount);
        saveSerial.SaveParameters(CurrentPoints);
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
