using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActiveLevelConfiguration", menuName = "ActiveLevelConfiguration")]
public class ActiveLevelConfiguration : LevelConfiguration
{
    public void RefundLevelSettings(LevelConfiguration levelConfiguration)
    {
        ChangeParameters(levelConfiguration.Parameters);
    }
}
