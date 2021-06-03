using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMode : ModeContainer
{
    [SerializeField] private int swapParameter = 2;
    [Header("Massive variable increaser")]
    [SerializeField] private int firstValueIncreaser = 0;
    [SerializeField] private int secondValueIncreaser = 2;
    private int iterationValue => levelNumber % SettingsCount;

    public override void ChangeConfigurationsValuesOnWin()
    {
        if (levelNumber % swapParameter != 0)
        {
            levelParameters[firstValueIncreaser] = 1;
            levelParameters[secondValueIncreaser] = 0;
        }
        else
        {
            levelParameters[firstValueIncreaser] = 0;
            levelParameters[secondValueIncreaser] = 1;
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
