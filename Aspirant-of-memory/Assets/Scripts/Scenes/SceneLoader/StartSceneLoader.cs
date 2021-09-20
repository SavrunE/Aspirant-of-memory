using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveSerial))]
public class StartSceneLoader : MonoBehaviour
{
    private SaveSerial saveSerial;
    public ActiveLevelConfiguration ActiveLevelConfigurationSettings;

    private void Start()
    {
        saveSerial = GetComponent<SaveSerial>();
        LoadProgress();
        DefaultLevel.Load(ActiveLevelConfigurationSettings);
    }

    private void LoadProgress()
    {
        saveSerial.LoadGame();
        MySingleton.Instance.ActiveMode = saveSerial.Mode();
        Debug.Log(saveSerial.Mode());
    }
}
