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
<<<<<<< HEAD
        MySingleton.Instance.ActiveMode = saveSerial.Mode();
        Debug.Log(saveSerial.Mode());
=======
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e
    }
}
