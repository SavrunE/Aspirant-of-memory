using IJunior.TypedScenes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//поля задаются в начальной сцене, в дефолтный левел заносятся при загрузке из синглтона
public class ModesContainer : MonoBehaviour
{
    public ModeContainer[] allModes;
    [SerializeField] private ModeContainer activeMode;
    public ModeContainer ActiveMode => allModes[0];
    [SerializeField] private NextModeAnimation nextModeAnimation;

    public Action<ModeContainer> OnModeChanged;


    private void Start()
    {
        MySingleton.Instance.ModesContainer = this;
    }

    public void ChangeActiveMode(ModeContainer mode)
    {
        activeMode = mode;
    }
    public void ChangeActiveMode(ModeContainer mode, bool PlayChangeModeAnimation)
    {
        activeMode = mode;

        if (PlayChangeModeAnimation == true)
        {
            nextModeAnimation.StartAnimation();
        }
    }

    public ModeContainer TakeNextMode(ModeContainer currentMode)
    {
        int i = 0;
        foreach (var mode in allModes)
        {
            if (mode == currentMode)
            {
                if (allModes[i + 1] != null)
                {
                    ModeContainer modeParameter = allModes[i + 1];
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
