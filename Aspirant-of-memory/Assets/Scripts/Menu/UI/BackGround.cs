using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BackGround : MonoBehaviour
{
    private float backYScale;

    private void Start()
    {
        backYScale = GetComponentInChildren<BackLine>().TakeYScale();
    }

    public void ReplaceBackground()
    {
        Vector3 vector3 = transform.position;
        transform.DOMove(new Vector3(vector3.x, vector3.y + backYScale * 2, vector3.z), 0);
    }
}
