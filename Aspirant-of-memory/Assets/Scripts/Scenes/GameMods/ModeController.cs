using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ModeController : MonoBehaviour
{
    public static Mode CurrentMode { get; private set; }

    public void CheckNullCurrentMode(Mode mode)
    {
        if (CurrentMode == null)
        {
            Debug.Log("ModeController take " + mode);
            CurrentMode = mode;
        }
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
