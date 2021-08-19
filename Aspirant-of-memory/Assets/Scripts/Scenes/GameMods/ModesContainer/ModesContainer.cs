using IJunior.TypedScenes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//поля задаются в начальной сцене, в дефолтный левел заносятся при загрузке из синглтона
public class ModesContainer : MonoBehaviour
{
    public Mode[] allModes;
    [SerializeField] private Mode activeMode;
    public Mode ActiveMode => allModes[0];
    [SerializeField] private NextModeAnimation nextModeAnimation;

    public Action<Mode> OnModeChanged;

    public void ChangeActiveMode(Mode mode)
    {
        activeMode = mode;
    }
    public void ChangeActiveMode(Mode mode, bool PlayChangeModeAnimation)
    {
        activeMode = mode;

        if (PlayChangeModeAnimation == true)
        {
            nextModeAnimation.StartAnimation();
        }
    }

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
                    modeParameter.ResetLevel();
                    nextModeAnimation.StartAnimation();

                    OnModeChanged?.Invoke(modeParameter);

                    return modeParameter;
                }
                else
                {
                    Debug.Log(allModes[i] + " was last");
                    return null;
                }
            }
            i++;
        }

        throw new Exeption("тут такого типо не должно было быть");
    }
}
