using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveSerial))]
public class SceneLoader : MonoBehaviour
{
    private SaveSerial saveSerial;

    private void Awake()
    {
        saveSerial = GetComponent<SaveSerial>();
        LoadProgress();
    }

    public void ActivateLevel(LevelConfiguration levelConfiguration)
    {
        DefaultLevel.Load(levelConfiguration);
    }

    public void LoadLevel(ActiveLevelConfiguration activeLevelConfiguration)
    {
        DefaultLevel.Load(activeLevelConfiguration);
    }

    private void LoadProgress()
    {
        saveSerial.LoadGame();
        // актив мод?
        Debug.Log("актив мод?");
    }
}
