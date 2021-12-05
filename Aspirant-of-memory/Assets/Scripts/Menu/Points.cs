using System;
using UnityEngine;

public class Points : MonoBehaviour
{
    [SerializeField] private int points;
    [SerializeField] private SaveSerial saveSerial;
    public int PointsCount => points;
    public event Action<int> OnPointsChanged;

    public int PointsValue => points;

    public void PointsIncrease(int value)
    {
        points += value;
        saveSerial.ParametersChanger(points);
        OnPointsChangedEvent();
    }

    public void PointsReduct(int value)
    {
        points -= value;
        saveSerial.ParametersChanger(points);
        OnPointsChangedEvent();
    }

    public void ChangePointsView(int points)
    {
        this.points = points;
        OnPointsChangedEvent();
    }

    private void OnPointsChangedEvent()
    {
        OnPointsChanged?.Invoke(points);
    }
}
