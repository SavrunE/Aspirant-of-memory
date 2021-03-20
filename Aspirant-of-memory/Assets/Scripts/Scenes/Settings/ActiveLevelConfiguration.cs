using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActiveLevelConfiguration", menuName = "ActiveLevelConfiguration")]
public class ActiveLevelConfiguration : LevelConfiguration
{
    [Header("Start level configuration")]
    [SerializeField] private LevelConfiguration startedLevelConfiguration;

    public void RefundLevelSettings()
    {
        ChangeParameters(startedLevelConfiguration.Parameters);
    }
}
