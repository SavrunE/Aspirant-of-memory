using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLine : MonoBehaviour
{
    public float TakeYScale()
    {
        float yScale = 0f;
        var childrens = transform.GetComponentsInChildren<Transform>();
        foreach (var children in childrens)
        {
            yScale += children.localScale.y * 4;
        }
        return yScale;
    }
}
