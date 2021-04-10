using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModsContainer : MonoBehaviour
{
    public Mode[] allModes;

    public Mode TakeNextMode(Mode currentMode)
    {
        int i = 0;
        foreach (var mode in allModes)
        {
            if (mode == currentMode)
            {
                if (allModes[i + 1] != null)
                {
                    Mode modeParameter = allModes[i + 1];
                    Debug.Log(modeParameter);
                    modeParameter.ResetLevelNumber();
                    modeParameter.RefundLevelSettings();
                    //levelLoader.SetActiveMode(modeParameter);

                    return modeParameter;
                }
                else
                {
                    Debug.Log(allModes[i] + " is last");
                    return null;
                }
            }
            i++;
        }
        return null;
    }
}
