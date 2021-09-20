using IJunior.TypedScenes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModesContainer : MonoBehaviour
{
<<<<<<< HEAD:Aspirant-of-memory/Assets/Scripts/Scenes/GameMods/ModesContainer.cs
    //public static ModesContainer Instance;
=======
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e:Aspirant-of-memory/Assets/Scripts/Scenes/GameMods/ModesContainer/ModesContainer.cs
    public Mode[] allModes;
    [SerializeField] private Mode activeMode;
    public Mode ActiveMode => allModes[0];
    [SerializeField] private NextModeAnimation nextModeAnimation;

<<<<<<< HEAD:Aspirant-of-memory/Assets/Scripts/Scenes/GameMods/ModesContainer.cs
    private void Start()
    {
        MySingleton.Instance.Modes = allModes;
        MySingleton.Instance.ActiveMode = ActiveMode;
        Debug.Log(MySingleton.Instance.ActiveMode);
        Debug.Log(ActiveMode);
        MySingleton.Instance.ModesContainer = this;
    }

    private void Awake()
=======
    public Action<Mode> OnModeChanged;

    public void ChangeActiveMode(Mode mode)
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e:Aspirant-of-memory/Assets/Scripts/Scenes/GameMods/ModesContainer/ModesContainer.cs
    {
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //    }
    //    else if(Instance == this)
    //    {
    //        Destroy(gameObject);
    //    }

    //    DontDestroyOnLoad(this);
    }
<<<<<<< HEAD:Aspirant-of-memory/Assets/Scripts/Scenes/GameMods/ModesContainer.cs

    public void ChangeActiveMode(Mode mode)
=======
    public void ChangeActiveMode(Mode mode, bool PlayChangeModeAnimation)
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e:Aspirant-of-memory/Assets/Scripts/Scenes/GameMods/ModesContainer/ModesContainer.cs
    {
        activeMode = mode;
        nextModeAnimation.StartAnimation();
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
