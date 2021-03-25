using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelLoader))]
public class ModsContainer : MonoBehaviour
{
    [HideInInspector]
    public Mode[] Mods;
    
    [SerializeField] private ActiveLevelConfiguration activeLevelConfigurationSettings;
    [SerializeField] private Mode activeMode;
    private LevelLoader levelLoader;

    public Mode ActiveMode => activeMode;

    private void Awake()
    {
        levelLoader = GetComponent<LevelLoader>();

        TakeModsInChildren();
    }

    private void TakeModsInChildren()
    {
        Mods = GetComponentsInChildren<Mode>();
        foreach (var mode in Mods)
        {
            mode.ChangeActiveLevelConfiguration(activeLevelConfigurationSettings);
            CheckActiveMode(mode);
        }
    }

    private void CheckActiveMode(Mode mode)
    {
        if (activeMode == mode)
        {
            levelLoader.SetActiveMode(mode);
        }
    }
}
