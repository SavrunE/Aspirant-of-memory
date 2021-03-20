using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSwitch : MonoBehaviour
{
    public void Switch()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
