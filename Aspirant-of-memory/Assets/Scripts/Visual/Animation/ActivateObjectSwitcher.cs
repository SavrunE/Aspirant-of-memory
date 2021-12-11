using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateObjectSwitcher : MonoBehaviour
{
    public void Deactive()
    {
        gameObject.GetComponent<Canvas>().planeDistance = 0f;
    }

    public void Activate()
    {
        gameObject.GetComponent<Canvas>().planeDistance = 1f;
    }
}
