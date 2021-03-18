using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActiveLevelConfiguration", menuName = "ActiveLevelConfiguration")]
public class ActiveLevelConfiguration : LevelConfiguration
{
    [SerializeField] private LevelConfiguration startedLevelConfiguration;
}
