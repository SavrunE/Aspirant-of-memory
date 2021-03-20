using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mode : MonoBehaviour
{
    public ActiveLevelConfiguration ActiveLevelConfigurationSettings;
    public int CurrentPoints { get; private set; }
    public int PointsForWinLevel { get; private set; }
    public int MaxModePoints { get; private set; }

    public abstract void ChangeConfigurationsValues();
    public abstract void NextLevelLoad();
    public abstract void RestartLevel();
    public abstract void RefundLevelSettings();


}
