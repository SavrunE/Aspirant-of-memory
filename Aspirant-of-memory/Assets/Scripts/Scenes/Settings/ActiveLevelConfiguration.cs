using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ActiveLevelConfiguration", menuName = "ActiveLevelConfiguration")]
public class ActiveLevelConfiguration : LevelConfiguration
{
    public int MaxOpenLevel { get; private set; }
    public int StageLevelNumber { get; private set; }

    public override void IncreaseButtonsCount()
    {
        buttonsCount++;
    }
    
    public override void IncreaseButtonsCountMaximumSpace()
    {
        buttonsCountMaximumSpace++;
    }
    
    public override void IncreaseQueueLength()
    {
        queueLength++;
    }
    
    public override void IncreaseQueueLengthMaximumSpace()
    {
        queueLengthMaximumSpace++;
    }
    
    public override void IncreaseRotateOffset()
    {
        rotateOffset++;
    }
    
    public override void IncreaseRotateOffsetMaximumSpace()
    {
        rotateOffsetMaximumSpace++;
    }

    public override void IncreaseStageLevelNumber()
    {
        StageLevelNumber++;
    }

    public void ChangeMaxOpenLevel(int newMaxOpenLevel)
    {
        MaxOpenLevel = newMaxOpenLevel;
    }

    public void RefundLevelSettings(int[] parameters)
    {
        ChangeParameters(parameters);
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

    public override void ResetStageLevelNumber()
    {
        StageLevelNumber = 0;
    }
}
