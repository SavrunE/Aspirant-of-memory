using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderOpenLevels : MonoBehaviour
{
    private LevelOpener[] levelOpeners;
    private List<int> openLevels;

    public void LoadOpenLevels(List<int> openLevels)
    {
        this.openLevels = openLevels;
        levelOpeners = GetComponentsInChildren<LevelOpener>();
        int levelNumber = 0;
        foreach (LevelOpener levelOpen in levelOpeners)
        {
            levelNumber++;

            levelOpen.CloseLevel();
            levelOpen.SetLevelNumber(levelNumber);
        }

        foreach (int openLevel in openLevels)
        {
            foreach (LevelOpener levelOpen in levelOpeners)
            {
                if (levelOpen.LevelNumber == openLevel)
                {
                    levelOpen.OpenLevel();
                }
            }
        }
    }
}
