using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveSerial))]
public class StartSceneLoader : MonoBehaviour
{
    private SaveSerial saveSerial;
    public LevelConfiguration LevelConfigurationSettings;

    private void Start()
    {
        saveSerial = GetComponent<SaveSerial>();
        LoadProgress();
        DefaultLevel.Load(LevelConfigurationSettings);
    }

    private void LoadProgress()
    {
        saveSerial.LoadGame();
        // актив мод?
        Debug.Log("актив мод?");
    }
}
