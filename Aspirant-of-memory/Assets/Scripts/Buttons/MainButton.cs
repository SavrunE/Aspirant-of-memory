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
            Debug.Log("У кнопки нет эфекта " + this.gameObject.name);
        }
    }
    public void Activate()
    {
        effect.Activate();
    }
}
