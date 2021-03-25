using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMode : Mode
{
    private int iterationValue => levelNumber % SettingsCount;

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
        activeLevelConfigurationSettings.IncreaseParameters(levelParameters);
    }
}
