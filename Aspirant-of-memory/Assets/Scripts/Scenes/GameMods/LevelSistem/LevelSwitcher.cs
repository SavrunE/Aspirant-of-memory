using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    private LevelOpen levelOpen;
    private LevelClose levelClose;

    private void Start()
    {
        levelOpen = GetComponentInChildren<LevelOpen>();
        levelClose = GetComponentInChildren<LevelClose>();
        levelOpen.gameObject.SetActive(false);
    }
}
