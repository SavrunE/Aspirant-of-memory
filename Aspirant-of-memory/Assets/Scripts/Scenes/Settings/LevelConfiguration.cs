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
        return Random.Range(baseValue, baseValue + overValue + 1);
    }

    public List<int> TakeParameters()
    {
        List<int> parameters = new List<int>(0);
        parameters.AddRange(Parameters);

        return parameters;
    }
}
