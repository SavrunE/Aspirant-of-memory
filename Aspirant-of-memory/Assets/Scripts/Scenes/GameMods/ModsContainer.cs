using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LevelLoader))]
[RequireComponent(typeof(ModeController))]
public class ModsContainer : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    [SerializeField] private ActiveLevelConfiguration activeLevelConfigurationSettings;
    [SerializeField] private Mode startMode;
    [SerializeField] private Mode[] allModes;

    private LevelLoader levelLoader;
    [HideInInspector]
    public ModeController ModeController;

    [HideInInspector]
    public Mode[] Mods;

    public void OnSceneLoaded(LevelConfiguration argument)
    {
        levelLoader = GetComponent<LevelLoader>();
    }

    private void Start()
    {
        modeActivator();
    }
    private void modeActivator()
    {
        ModeController = GetComponent<ModeController>();
        TakeModsInChildren();
    }

    private void TakeModsInChildren()
    {
        Mods = GetComponentsInChildren<Mode>();
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
                    levelLoader.SetActiveMode(modeParameter);

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
