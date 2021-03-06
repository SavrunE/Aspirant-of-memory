using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorChanger))]
public class ButtonEffect : MonoBehaviour, IButtonEffect
{
    public Button buttonParent { get; private set; }

    private ColorChanger colorChanger;

    private void Awake()
    {
        colorChanger = GetComponent<ColorChanger>();

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

    public void TakeBaseColor(int elementNumber)
    {
        colorChanger.ChangeBaseColor(elementNumber, ColorSettings.Instance.effectAlpha);
    }
}
