using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMode : Mode
{
    [SerializeField] private int swapParameter = 2;
    [SerializeField] private int firstValueIncreaser = 0;
    [SerializeField] private int secondValueIncreaser = 1;
    private int iterationValue => levelNumber % SettingsCount;

    public override void ChangeConfigurationsValuesOnWin()
    {
        if (levelNumber % swapParameter == 0)
        {
            levelParameters[secondValueIncreaser]++;
        }
        else
        {
            levelParameters[firstValueIncreaser]++;
        }
        activeLevelConfigurationSettings.IncreaseParameters(levelParameters);
    }

    private void AllPluseOne()
    {
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
