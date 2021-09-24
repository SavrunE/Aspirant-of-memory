using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ActiveLevelConfiguration", menuName = "ActiveLevelConfiguration")]
public class ActiveLevelConfiguration : LevelConfiguration
{
    public int MaxOpenLevel { get; private set; }
    public int StageLevelNumber { get; private set; }

    public void IncreaseButtonsCount()
    {
        buttonsCount++;
    }
    
    public void IncreaseButtonsCountMaximumSpace()
    {
        buttonsCountMaximumSpace++;
    }
    
    public void IncreaseQueueLength()
    {
        queueLength++;
    }
    
    public void IncreaseQueueLengthMaximumSpace()
    {
        queueLengthMaximumSpace++;
    }
    
    public void IncreaseRotateOffset()
    {
        rotateOffset++;
    }
    
    public void IncreaseRotateOffsetMaximumSpace()
    {
        rotateOffsetMaximumSpace++;
    }

    public void IncreaseStageLevelNumber()
    {
        StageLevelNumber++;
    }

    public void ChangeMaxOpenLevel(int newMaxOpenLevel)
    {
        MaxOpenLevel = newMaxOpenLevel;
    }

    public void RefundLevelSettings(LevelConfiguration levelConfiguration)
    {
        ChangeParameters(levelConfiguration.Parameters);
    }

    private void ChangeParameters(int[] changeValue)
    {
        int i = 0;
        buttonsCount = changeValue[i++];
        buttonsCountMaximumSpace = changeValue[i++];
        queueLength = changeValue[i++];
        queueLengthMaximumSpace = changeValue[i++];
        rotateOffset = changeValue[i++];
        rotateOffsetMaximumSpace = changeValue[i++];
    }

    public void RefundStageLevelNumber()
    {
        StageLevelNumber = 0;
    }
}
