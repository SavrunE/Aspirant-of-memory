using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    public Sequence Queue { get; private set; }

    private void Awake()
    {
        TryGetParentSequence();
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
    }
}
