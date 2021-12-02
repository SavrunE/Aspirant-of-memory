using System;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private int points;
    public int PointsCount => points;
    public event Action<int> OnPointsChanged;

    public int PointsValue => points;

    public void PointsIncrease(int value)
    {
        points += value;
        OnPointsChangedEvent();
    }

    public void PointsReduct(int value)
    {
        points -= value;
        OnPointsChangedEvent();
    }

    public void ChangePoints(int points)
    {
        this.points = points;
        OnPointsChangedEvent();
    }

    private void OnPointsChangedEvent()
    {
        OnPointsChanged?.Invoke(points);
    }
}
