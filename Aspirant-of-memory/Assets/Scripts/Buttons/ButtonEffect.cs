using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour, IButtonEffect
{
    public void Activate() 
    {
        Debug.Log("Activated");
    }
}
