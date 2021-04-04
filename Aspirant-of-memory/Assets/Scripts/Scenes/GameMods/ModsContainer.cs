using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelLoader))]
[RequireComponent(typeof(ModeController))]
public class ModsContainer : MonoBehaviour
{
    [SerializeField] private ActiveLevelConfiguration activeLevelConfigurationSettings;
    [SerializeField] private Mode startMode;

    private LevelLoader levelLoader;
    [HideInInspector]
    public ModeController ModeController;

    [HideInInspector]
    public Mode[] Mods;

    private void Awake()
    {
        levelLoader = GetComponent<LevelLoader>();
        modeActivator();
    }

    private void modeActivator()
    {
        ModeController = GetComponent<ModeController>();
        ModeController.CheckNullCurrentMode(startMode);
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
        if (ModeController.TakeCurrentMode() == mode)
        {
            levelLoader.SetActiveMode(mode);
        }
    }

    public Mode TakeNextMode(Mode currentMode)
    {
        int i = 0;
        foreach (var mode in Mods)
        {
            if (mode == ModeController.CurrentMode)
            {
                if (Mods[i + 1] != null)
                {
                    Mode modeParameter = Mods[i + 1];
                    Debug.Log(modeParameter);
                    modeParameter.ResetLevelNumber();
                    modeParameter.RefundLevelSettings();

                    return modeParameter;
                }
                else
                {
                    Debug.Log(Mods[i] + " is last");
                    return null;
                }
            }
            i++;
        }
        return null;
    }
}
