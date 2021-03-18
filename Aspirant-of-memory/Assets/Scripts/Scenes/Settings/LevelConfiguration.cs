using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New config", menuName = "Config")]
public class LevelConfiguration : ScriptableObject
{
    [SerializeField] private int buttonsCount;
    [SerializeField] private int buttonsCountRangeOver;

    [SerializeField] private int queueLength;
    [SerializeField] private int queueLengthRangeOver;

    [SerializeField] private int rotateOffset;
    [SerializeField] private int rotateOffsetRangeOver;

    public int ButtonsCount => RangeOverSize(buttonsCount, buttonsCountRangeOver);
    public int QueueLength => RangeOverSize(queueLength, queueLengthRangeOver);
    public int RotateLength => RangeOverSize(rotateOffset, rotateOffsetRangeOver);

    private int RangeOverSize(int baseValue, int overValue)
    {
        return Random.Range(baseValue, baseValue + overValue + 1);
    }

    public void ChangeValues(int value)
    {
        buttonsCount += value;
    }
}
