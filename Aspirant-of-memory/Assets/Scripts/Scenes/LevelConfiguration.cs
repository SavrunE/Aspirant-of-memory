using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New config", menuName = "Config")]
public class LevelConfiguration : ScriptableObject
{
    [SerializeField] private int buttonsCount;

    public int ButtonsCount => buttonsCount;
}
