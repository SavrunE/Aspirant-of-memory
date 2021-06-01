using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    [SerializeField] protected LevelInformant levelInformant;

    public abstract void NextLevel();
}
