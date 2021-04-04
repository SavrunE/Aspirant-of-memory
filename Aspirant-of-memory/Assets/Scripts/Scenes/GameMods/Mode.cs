using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using IJunior.TypedScenes;

public abstract class Mode : MonoBehaviour
{
    protected static int levelNumber;
    [SerializeField] protected int maxLevel = 5;

    protected ActiveLevelConfiguration activeLevelConfigurationSettings;
    [SerializeField] protected LevelConfiguration startLevelConfiguration;
    public int CurrentPoints { get; private set; }
    public int PointsForWinLevel { get; private set; }
    public int MaxModePoints { get; private set; }

    protected int[] levelParameters;
    protected int SettingsCount => activeLevelConfigurationSettings.TakeParameters().Count;
    public int LevelNumber => levelNumber;
    public Action<int> OnLevelChanged;

    public abstract void ChangeConfigurationsValuesOnWin();
    public void ChangeConfigurationsValues() 
    {
        levelNumber++;
        ChangeConfigurationsValuesOnWin();
    }

    private void Start()
    {
        levelParameters = new int[SettingsCount];
    }

    public void ChangeActiveLevelConfiguration(ActiveLevelConfiguration activeLevelConfigurationSettings)
    {
        this.activeLevelConfigurationSettings = activeLevelConfigurationSettings;
    }

    public void LevelComplete(ModsContainer modsContainer)
    {
        if (levelNumber >= maxLevel)
        {
            Debug.Log("�������� ��������� LevelConfiguration ���������, " +
                "������� ������ ��� �������� �� ���� ��� " +
                "������ ������ ������ � �������� �����-������");

            modsContainer.TakeNextMode(this);
            NextLevelLoad();
        }
        else
        {
            NextLevelLoad();
        }
    }

    public void NextLevelLoad()
    {
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
        activeLevelConfigurationSettings.RefundLevelSettings(startLevelConfiguration);
        DefaultLevel.Load(activeLevelConfigurationSettings);
    }

    public void ResetLevelNumber()
    {
        levelNumber = 0;
    }
}
