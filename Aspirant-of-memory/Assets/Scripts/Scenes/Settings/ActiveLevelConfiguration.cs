using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ActiveLevelConfiguration", menuName = "ActiveLevelConfiguration")]
public class ActiveLevelConfiguration : LevelConfiguration
{
    private int stageLevelNumber;

    public override int MaxStageLevelNumberInfo()
    {
        return maxStageLevel;
    }

    public override int StageLevelNumberInfo()
    {
        return stageLevelNumber;
    }

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
        stageLevelNumber++;
    }

    public void RefundLevelSettings(int[] parameters)
    {
        ChangeParameters(parameters);
    }

    public void ChangeParameters(int[] changeValue)
    {
        int i = 0;
        maxStageLevel = changeValue[i++];
        buttonsCount = changeValue[i++];
        buttonsCountMaximumSpace = changeValue[i++];
        queueLength = changeValue[i++];
        queueLengthMaximumSpace = changeValue[i++];
        rotateOffset = changeValue[i++];
        rotateOffsetMaximumSpace = changeValue[i++];
        pointsAfterWinStageLevel = changeValue[i++];
        pointsAfterEndLevel = changeValue[i++];
    }

    public override void ResetStageLevelNumber()
    {
        stageLevelNumber = 0;
    }
}
