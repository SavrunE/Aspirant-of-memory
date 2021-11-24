using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelConfiguration", menuName = "LevelConfiguration")]
public class LevelConfiguration : ScriptableObject
{
    public int CurrentLevel { get; private set; }

    [SerializeField] protected int maxStageLevel = 5;

    [Header("Level configuration")]
    [SerializeField] protected int buttonsCount;
    [SerializeField] protected int buttonsCountMaximumSpace;

    [SerializeField] protected int queueLength;
    [SerializeField] protected int queueLengthMaximumSpace;

    [SerializeField] protected int rotateOffset;
    [SerializeField] protected int rotateOffsetMaximumSpace;

    [Header("Limitations")]
    [SerializeField] protected int maxButtons = 8;
    [SerializeField] protected int maxLengthCount = 16;

    [Header("Change parameters setting")]
    [SerializeField] protected int buttonsCountChangeEveryStageLevel;
    [SerializeField] protected int buttonsCountMaximumSpaceChangeEveryStageLevel;

    [SerializeField] protected int queueLengthChangeEveryStageLevel;
    [SerializeField] protected int queueLengthMaximumSpaceChangeEveryStageLevel;

    [SerializeField] protected int rotateOffsetChangeEveryStageLevel;
    [SerializeField] protected int rotateOffsetMaximumSpaceChangeEveryStageLevel;

    public int MaxButtons => maxButtons;
    public int MaxLengthCount => maxLengthCount;
    public int MaxRotate => maxButtons / 2;
    public int ButtonsCount => RangeOverSize(buttonsCount, buttonsCountMaximumSpace);
    public int QueueLength => RangeOverSize(queueLength, queueLengthMaximumSpace);
    public int RotateLength => RangeOverSize(rotateOffset, rotateOffsetMaximumSpace);

    public int[] Parameters => new int[] {
        buttonsCount, buttonsCountMaximumSpace,
        queueLength, queueLengthMaximumSpace,
        rotateOffset , rotateOffsetMaximumSpace };

    private int RangeOverSize(int baseValue, int overValue)
    {
        int currentValue = Random.Range(baseValue, baseValue + overValue + 1);
        Debug.Log(currentValue);
        return currentValue;
    }

    public List<int> TakeParameters()
    {
        List<int> parameters = new List<int>(0);
        parameters.AddRange(Parameters);

        return parameters;
    }

    public void SpecificChangeParametersSettings()
    {
        if (ModuloCheckWithStageLevelNumber(buttonsCountChangeEveryStageLevel))
        {
            IncreaseButtonsCount();
        }
        if (ModuloCheckWithStageLevelNumber(buttonsCountMaximumSpaceChangeEveryStageLevel))
        {
            IncreaseButtonsCountMaximumSpace();
        }
        if (ModuloCheckWithStageLevelNumber(queueLengthChangeEveryStageLevel))
        {
            IncreaseQueueLength();
        }
        if (ModuloCheckWithStageLevelNumber(queueLengthMaximumSpaceChangeEveryStageLevel))
        {
            IncreaseQueueLengthMaximumSpace();
        }
        if (ModuloCheckWithStageLevelNumber(rotateOffsetChangeEveryStageLevel))
        {
            IncreaseRotateOffset();
        }
        if (ModuloCheckWithStageLevelNumber(rotateOffsetMaximumSpaceChangeEveryStageLevel))
        {
            IncreaseRotateOffsetMaximumSpace();
        }
    }

    private bool ModuloCheckWithStageLevelNumber(int checkParameter)
    {
        if (checkParameter != 0 && StageLevelNumberInfo() % checkParameter == 0)
        {
            return true;
        }
        return false;
    }
    public virtual int StageLevelNumberInfo()
    {
        throw new System.NotImplementedException();
    }

    public virtual void IncreaseButtonsCount()
    {
        throw new System.NotImplementedException();
    }

    public virtual void IncreaseButtonsCountMaximumSpace()
    {
        throw new System.NotImplementedException();
    }

    public virtual void IncreaseQueueLength()
    {
        throw new System.NotImplementedException();
    }

    public virtual void IncreaseQueueLengthMaximumSpace()
    {
        throw new System.NotImplementedException();
    }

    public virtual void IncreaseRotateOffset()
    {
        throw new System.NotImplementedException();
    }

    public virtual void IncreaseRotateOffsetMaximumSpace()
    {
        throw new System.NotImplementedException();
    }

    public virtual void IncreaseStageLevelNumber()
    {
        throw new System.NotImplementedException();
    }

    public virtual void ResetStageLevelNumber()
    {
        throw new System.NotImplementedException();
    }
}
