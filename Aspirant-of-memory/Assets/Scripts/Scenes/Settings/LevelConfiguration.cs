using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New config", menuName = "Config")]
public class LevelConfiguration : ScriptableObject
{
    [Header("Level configuration")]
    [SerializeField] private int buttonsCount;
    [SerializeField] private int buttonsCountRangeOver;

    [SerializeField] private int queueLength;
    [SerializeField] private int queueLengthRangeOver;

    [SerializeField] private int rotateOffset;
    [SerializeField] private int rotateOffsetRangeOver;

    [Header("Limitations")]
    [SerializeField] private int maxButtons = 8;
    [SerializeField] private int maxLengthCount = 16;
    public int MaxButtons => maxButtons;
    public int MaxLengthCount => maxLengthCount;
    public int MaxRotate => maxButtons / 2;
    public int ButtonsCount => RangeOverSize(buttonsCount, buttonsCountRangeOver);
    public int QueueLength => RangeOverSize(queueLength, queueLengthRangeOver);
    public int RotateLength => RangeOverSize(rotateOffset, rotateOffsetRangeOver);

    private int RangeOverSize(int baseValue, int overValue)
    {
        return Random.Range(baseValue, baseValue + overValue + 1);
    }

    public List<int> TakeParameters()
    {
        List<int> parameters = new List<int>(0);
        parameters.AddRange(new int[] {
         buttonsCount,  buttonsCountRangeOver,
         queueLength,  queueLengthRangeOver,
         rotateOffset,  rotateOffsetRangeOver});

        return parameters;
    }

    public void IncreaseParameters(int[] changeValue)
    {
        int i = 0;
        if (buttonsCount + 1 + buttonsCountRangeOver <= MaxButtons)
        {
            buttonsCount += changeValue[i++];
            buttonsCountRangeOver += changeValue[i++];
        }
        if (queueLength + 1 + queueLengthRangeOver <= MaxLengthCount)
        {
            queueLength += changeValue[i++];
            queueLengthRangeOver += changeValue[i++];
        }
        rotateOffset += changeValue[i++];
        rotateOffsetRangeOver += changeValue[i++];
    }
}
