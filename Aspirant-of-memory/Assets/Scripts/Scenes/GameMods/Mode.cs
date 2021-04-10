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

    [SerializeField] protected ActiveLevelConfiguration activeLevelConfigurationSettings;
    [SerializeField] protected LevelConfiguration startLevelConfiguration;
    public int CurrentPoints { get; private set; }
    public int PointsForWinLevel { get; private set; }
    public int MaxModePoints { get; private set; }

    protected int[] levelParameters;
    protected int SettingsCount => startLevelConfiguration.TakeParameters().Count;
    public int LevelNumber => levelNumber;
    public Action<int> OnLevelChanged;
    public Action<Mode> OnModeChanged;

    public abstract void ChangeConfigurationsValuesOnWin();
    public void ChangeConfigurationsValues() 
    {
        levelNumber++;
        ChangeConfigurationsValuesOnWin();
    }

    private void Awake()
    {
        levelParameters = new int[SettingsCount];
    }

    public void LevelComplete(ModsContainer modsContainer)
    {
        if (levelNumber >= maxLevel)
        {
            Debug.Log("Получить следующий LevelConfiguration сложности, " +
                "сделать кнопку для перехода на него или " +
                "кнопку Начать занаво и получить бонус-поинты");
            Mode nextMode = modsContainer.TakeNextMode(this);
            OnModeChanged?.Invoke(nextMode);
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
