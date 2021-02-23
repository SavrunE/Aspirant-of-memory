using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ColorChanger))]
public class ButtonEffect : MonoBehaviour, IButtonEffect
{
    public Button buttonParent;

    private ColorChanger colorChanger;

    private void Start()
    {
        colorChanger = GetComponent<ColorChanger>();
    }

    public void OnClick() 
    {
        buttonParent.OnClick();
    }

    public void ChangeCollor()
    {
        colorChanger.ChangeCollor();
    }
}
