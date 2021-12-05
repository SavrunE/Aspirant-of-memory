using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderOpenLevels : MonoBehaviour
{
    private LevelOpener[] levelOpeners;
    public void LoadOpenLevels(List<int> openLevels)
    {
        levelOpeners = GetComponentsInChildren<LevelOpener>();
        int levelNumber = 0;
        foreach (LevelOpener levelOpen in levelOpeners)
        {
            levelOpen.CloseLevel();
            
            levelNumber++;
            
            levelOpen.SetLevelNumber(levelNumber);

            foreach (int openLevel in openLevels)
            {
                if (openLevel == levelNumber)
                {
                    levelOpen.OpenLevel();
                }
            }
        }
    }
}
