using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButton : MonoBehaviour, IButtonEffect
{
    private ButtonEffect effect;

    private void Start()
    {
        effect = GetComponentInChildren<ButtonEffect>();
        if (effect == null)
        {
            Debug.Log("� ������ ��� ������ " + this.gameObject.name);
        }
    }
    public void Activate()
    {
        effect.Activate();
    }
}
