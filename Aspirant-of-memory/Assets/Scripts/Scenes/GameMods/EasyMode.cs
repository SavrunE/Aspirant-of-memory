using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class EasyMode : Mode
{
    private static int levelNumber;
    private int[] levelParameters;
    private int SettingsCount => ActiveLevelConfigurationSettings.TakeParameters().Count;
    private int iterationValue => levelNumber % SettingsCount;

    private void Start()
    {
        levelParameters = new int[SettingsCount];
    }

    public override void ChangeConfigurationsValues()
    {
        levelNumber++;
        for (int i = 0; i < SettingsCount; i++)
        {
            if (i == iterationValue)
            {
                levelParameters[i]++;
            }
        }
        ActiveLevelConfigurationSettings.IncreaseParameters(levelParameters);
    }

    public override void NextLevelLoad()
    {
        ChangeConfigurationsValues();
        DefaultLevel.Load(ActiveLevelConfigurationSettings);
    }

    public override void RestartLevel()
    {
        DefaultLevel.Load(ActiveLevelConfigurationSettings);
    }

    public override void RefundLevelSettings()
    {
        ActiveLevelConfigurationSettings.RefundLevelSettings();
    }
}
