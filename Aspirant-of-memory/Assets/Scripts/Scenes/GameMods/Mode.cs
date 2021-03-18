using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mode : MonoBehaviour
{
    public int CurrentPoints { get; private set; }
    public int PointsForWinLevel { get; private set; }
    public int MaxModePoints { get; private set; }

    public LevelConfiguration LevelConfigurationSettings;

    public abstract void ChangeConfigurationsValues();
    public abstract void NextLevelLoad();
    public abstract void ReloadLevel();
}
