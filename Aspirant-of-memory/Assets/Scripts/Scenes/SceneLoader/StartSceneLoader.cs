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
        MySingleton.Instance.ModesContainer = GetComponentInChildren<ModesContainer>();
        if (MySingleton.Instance.ModesContainer == null)
        {
            throw new Exeption("ModesContainer on start window == null");
        }
        MySingleton.Instance.ModesContainer.ChangeActiveMode(saveSerial.Mode());
        Debug.Log(saveSerial.Mode());
    }
}
