using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SaveSerial))]
public class SceneLoader : MonoBehaviour
{
    private SaveSerial saveSerial;
    [SerializeField] private Points points;
    [SerializeField] private ActiveLevelConfiguration activeLevelConfiguration;
    [SerializeField] private LoaderOpenLevels loaderOpenLevels;

    public void Start()
    {
        saveSerial = GetComponent<SaveSerial>();
        saveSerial.LoadGame();
        points.ChangePoints(activeLevelConfiguration.PointsInfo());
        loaderOpenLevels.LoadOpenLevels(saveSerial.OpenLevels());
    }

    public void ActivateLevel(LevelConfiguration levelConfiguration)
    {
        activeLevelConfiguration.ResetStageLevelNumber();
        activeLevelConfiguration.ChangeParameters(levelConfiguration.Parameters);
        DefaultLevel.Load(activeLevelConfiguration);
    }

    public void NextStageLevelLoad(ActiveLevelConfiguration activeLevelConfiguration)
    {
        DefaultLevel.Load(activeLevelConfiguration);
    }

    public void LoadLevel(ActiveLevelConfiguration activeLevelConfiguration)
    {
        DefaultLevel.Load(activeLevelConfiguration);
    }
}
