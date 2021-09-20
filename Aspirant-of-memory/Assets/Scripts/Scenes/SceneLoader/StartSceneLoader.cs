using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveSerial))]
public class StartSceneLoader : MonoBehaviour
{
    private SaveSerial saveSerial;
    private ModesContainer ModesContainer;
    public ActiveLevelConfiguration ActiveLevelConfigurationSettings;

    private void Start()
    {
        ModesContainer = GetComponentInChildren<ModesContainer>();
        saveSerial = GetComponent<SaveSerial>();
        LoadProgress();
        DefaultLevel.Load(ActiveLevelConfigurationSettings);
    }

    private void LoadProgress()
    {
        saveSerial.LoadGame();
        MySingleton.Instance.ActiveMode = saveSerial.Mode();
        MySingleton.Instance.ModesContainer = ModesContainer;
        Debug.Log(saveSerial.Mode());
    }
}
