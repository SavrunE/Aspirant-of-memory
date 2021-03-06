using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ColorChanger))]
public class Button : MonoBehaviour, IButtonEffect
{
    private ButtonEffect buttonEffect;
    private ButtonRotator buttonRotator;
    private ColorChanger colorChanger;

    private void Awake()
    {
        colorChanger = GetComponent<ColorChanger>();
        TryGetEffect();
        TryGetParentSequence();
    }

    private void TryGetEffect()
    {
        buttonEffect = GetComponentInChildren<ButtonEffect>();
        if (buttonEffect == null)
        {
            Debug.Log("У кнопки нет дочернего buttonEffect " + this.gameObject.name);
        }
    }

    private void TryGetParentSequence()
    {
        buttonRotator = transform.parent.GetComponent<ButtonRotator>();
        if (buttonRotator == null)
        {
            Debug.Log("У кнопки нет родительского buttonRotator " + this.gameObject.name);
        }
    }

    public void TakeBaseColor(int elementNumber)
    {
        colorChanger.ChangeBaseColor(elementNumber);
        buttonEffect.TakeBaseColor(elementNumber);
    }

    public void PutInQueue()
    {
        Activate();
    }

    public void OnClick()
    {
        buttonRotator.sequence.CheckButtonSelected(this);
    }

    public void Activate()
    {
        buttonEffect.ChangeCollor();
    }
}
