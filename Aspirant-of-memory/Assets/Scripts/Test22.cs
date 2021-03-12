using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test22 : MonoBehaviour
{
    private static float border = 0;

    public static float Border
    {
        get
        {
            if (border == 0)
            {
                var cam = Camera.main;
                border = cam.aspect * cam.orthographicSize;
            }
            return border;
        }
        private set { }
    }
    private void Start()
    {
        //var cam = Camera.main;
        //Debug.Log(cam.aspect);
        //Debug.Log(cam.orthographicSize);
    }
}
