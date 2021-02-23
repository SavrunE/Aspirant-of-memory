using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Button : MonoBehaviour, IButtonEffect
{
    public  ButtonEffect Effect { get; private set; }
    public Sequence Queue { get; private set; }

    private void Awake()
    {
        TryGetEffect();
        TryGetParentSequence();
    }

    private void TryGetEffect()
    {
        Effect = GetComponentInChildren<ButtonEffect>();
        if (Effect == null)
        {
            Debug.Log("У кнопки нет эфекта " + this.gameObject.name);
        }
        else
        {
            Effect.buttonParent = this;
        }
    }

    private void TryGetParentSequence()
    {
        Queue = transform.parent.GetComponent<Sequence>();
        if (Queue == null)
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
        Queue.CheckButtonSelected(this);
    }

    public void Activate()
    {
        Effect.ChangeCollor();
    }
}
