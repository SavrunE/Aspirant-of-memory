using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(ColorChanger))]
public class Button : MonoBehaviour, IButtonEffect
{
    private ButtonEffect buttonEffect;
    private Sequence sequence;
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
        sequence = transform.parent.GetComponent<Sequence>();
        if (sequence == null)
        {
            Debug.Log("У кнопки нет родительского sequence " + this.gameObject.name);
        }
    }

    public void TakeBaseColor(int element)
    {
        colorChanger.ChangeBaseColor(element);
    }

    public void PutInQueue()
    {
        Activate();
    }

    public void OnClick()
    {
        sequence.CheckButtonSelected(this);
    }

    public void Activate()
    {
        buttonEffect.ChangeCollor();
    }
}
