using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsUI : MonoBehaviour
{
    private Text text;
    [SerializeField] private Points points;

    private void Start()
    {
        text = GetComponent<Text>();
        ChangeText();
    }

    private void OnEnable()
    {
        points.OnPointsChanged += ChangeText;
    }

    private void OnDisable()
    {
        points.OnPointsChanged -= ChangeText;
    }
    public void ChangeText()
    {
        text.text = points.PointsValue.ToString();
    }
    public void ChangeText(int value)
    {
        text.text = value.ToString();
    }
}
