using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    private Image image;


    private void Start()
    {
        image = GetComponent<Image>();
        image.color = ColorSettings.Instance.colors[1];
    }
}
