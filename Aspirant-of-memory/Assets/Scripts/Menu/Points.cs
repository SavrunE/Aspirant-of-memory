using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private static int points;
    public int PointsCount => points;
    public event Action<int> OnPointsChanged;
    public StageLevelChanger stageLevelChanger;

    public int PointsValue => points;

    public void PointsIncrease(int value)
    {
        points += value;
        OnPointsChanged?.Invoke(points);
    }

    public void PointsReduct(int value)
    {
        points -= value;
        OnPointsChanged?.Invoke(points);
    }
}
