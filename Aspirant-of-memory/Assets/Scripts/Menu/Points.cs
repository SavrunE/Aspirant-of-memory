using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private static int points;
    public PointsUI PointsUI;
    public event Action<int> OnPointsChanged;

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
