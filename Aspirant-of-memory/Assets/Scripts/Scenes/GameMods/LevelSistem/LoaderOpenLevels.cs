using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderOpenLevels : MonoBehaviour
{
    private LevelOpener[] levelOpeners;
    public void LoadOpenLevels(List<int> openLevels)
    {
        levelOpeners = GetComponentsInChildren<LevelOpener>();
        int i = 0;
        foreach (LevelOpener levelOpen in levelOpeners)
        {
            i ++;
            foreach (int openLevel in openLevels)
            {
                if (openLevel == i)
                {
                    levelOpen.OpenLevel();
                }
            }
        }
    }
}
