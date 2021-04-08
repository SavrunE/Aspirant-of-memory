using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModeController : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    public static Mode CurrentMode { get; private set; }
    public void OnSceneLoaded(LevelConfiguration argument)
    {
        CurrentMode = argument.Mode;
    }
   
    public void ChangeCurrentMode(Mode mode)
    {
        CurrentMode = mode;
    }

    public Mode TakeCurrentMode()
    {
        return CurrentMode;
    }
}
