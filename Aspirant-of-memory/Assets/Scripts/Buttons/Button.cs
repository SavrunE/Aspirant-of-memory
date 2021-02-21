using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IButtonEffect
{
    private ButtonEffect effect;
    private Sequence queue;

    private void Awake()
    {
        TryGetEffect();
        TryGetParentSequence();
    }

    private void TryGetEffect()
    {
        effect = GetComponentInChildren<ButtonEffect>();
        if (effect == null)
        {
            Debug.Log("У кнопки нет эфекта " + this.gameObject.name);
        }
        else
        {
            effect.buttonParent = this;
        }
    }

    private void TryGetParentSequence()
    {
        queue = transform.parent.GetComponent<Sequence>();
        if (queue == null)
        {
            Debug.Log("У кнопки нет родительской очереди " + this.gameObject.name);
        }
    }

    public void PutInQueue()
    {
        Activate();
    }

    public void OnClick()
    {
        queue.CheckButtonSelected(this);
    }

    public void Activate()
    {
        effect.ChangeCollor();
    }
}
