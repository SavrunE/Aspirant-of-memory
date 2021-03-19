using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mode : MonoBehaviour
{
    public LevelConfiguration LevelConfigurationSettings;
    public int CurrentPoints { get; private set; }
    public int PointsForWinLevel { get; private set; }
    public int MaxModePoints { get; private set; }

    [SerializeField] private int maxButtons;
    [SerializeField] private int maxCount;
    private int maxRotate => maxButtons / 2;

    public int MaxButtons => maxButtons;
    public int MaxCount => maxCount;
    public int MaxRotate => maxRotate;

    private static int iterationCycle;

    public abstract void ChangeConfigurationsValues();
    public abstract void NextLevelLoad();
    public abstract void ReloadLevel();
}
