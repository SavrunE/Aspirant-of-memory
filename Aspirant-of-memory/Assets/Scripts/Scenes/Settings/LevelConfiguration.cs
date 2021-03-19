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

    public List<int> TakeValues()
    {
        List<int> numbers = new List<int>(0);
        numbers.AddRange(new int[] {
          buttonsCount,  buttonsCountRangeOver,
         queueLength,  queueLengthRangeOver,
         rotateOffset,  rotateOffsetRangeOver});

        return numbers;
    }

    public void ChangeValues(
        int buttonsCount, int buttonsCountRangeOver,
        int queueLength, int queueLengthRangeOver,
        int rotateOffset, int rotateOffsetRangeOver)
    {
        this.buttonsCount = buttonsCount;
        this.buttonsCountRangeOver = buttonsCountRangeOver;
        this.queueLength = queueLength;
        this.queueLengthRangeOver = queueLengthRangeOver;
        this.rotateOffset = rotateOffset;
        this.rotateOffsetRangeOver = rotateOffsetRangeOver;
    }
}
