using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSceneLoader : MonoBehaviour
{
    public ActiveLevelConfiguration ActiveLevelConfigurationSettings;
    private void Start()
    {
        DefaultLevel.Load(ActiveLevelConfigurationSettings);
    }
}
