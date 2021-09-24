using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMode : Mode
{
    public override void ChangeConfigurationsValuesOnWin()
    {
        activeLevelConfigurationSettings.IncreaseButtonsCount();
    }
}
