using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour
{
    private Text text;
    [SerializeField] private Points points;

    private void OnEnable()
    {
        text = GetComponent<Text>();
        ChangeText();
        points.OnPointsChanged += ChangeText;
    }

    private void OnDisable()
    {
        points.OnPointsChanged -= ChangeText;
    }
    public void ChangeText()
    {
        text.text = points.PointsCount.ToString();
    }
    public void ChangeText(int value)
    {
        if (value > 10000)
        {


            if (value > 10000000)
            {
                text.text = ((int)(value / 1000000)).ToString() + "kk";
            }
            else
            {
                if (value > 10000)
                {
                    text.text = ((int)(value / 1000)).ToString() + "k";
                }
            }
        }
        else
        {
            text.text = value.ToString();
        }
    }
}
