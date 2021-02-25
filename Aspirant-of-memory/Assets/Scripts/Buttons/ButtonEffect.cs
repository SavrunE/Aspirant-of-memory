using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
public class ButtonEffect : MonoBehaviour, IButtonEffect
{
    public Button buttonParent { get; private set; }

    private SpriteRenderer sprite;
    private float baseAlpha;

    private ColorChanger colorChanger;
    private float maxAlpha;
    private float speedEffect;

    private void Start()
    {
        colorChanger = GetComponent<ColorChanger>();
        sprite = GetComponent<SpriteRenderer>();
        baseAlpha = sprite.color.a;

        buttonParent = transform.parent.GetComponent<Button>();
    }

    public void OnClick()
    {
        buttonParent.OnClick();
    }

    public void ChangeCollor()
    {
        colorChanger.ChangeCollorAlpha();
    }
}
