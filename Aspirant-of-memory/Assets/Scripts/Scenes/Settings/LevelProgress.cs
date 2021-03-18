using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public void ChangeProgress(int currentValue, int maxValue)
    {

    }
}
