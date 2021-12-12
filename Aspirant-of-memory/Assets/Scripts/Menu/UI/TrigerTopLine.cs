using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerTopLine : MonoBehaviour
{
    private BackGround backGround;

    private void Start()
    {
        backGround = transform.parent.GetComponent<BackGround>();
    }

    public void ChangeYBackground()
    {
        backGround.ReplaceBackground();
    }
}
