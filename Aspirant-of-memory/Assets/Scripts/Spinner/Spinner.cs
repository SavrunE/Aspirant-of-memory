using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    private float horizontalCameraValue;

    [SerializeField] private float normalScale;

    //* horizontalCameraValue
    public float NormalScale => normalScale * horizontalCameraValue;


    private void Awake()
    {
        horizontalCameraValue = Camera.main.aspect;
        if (normalScale < 0.1f)
        {
            normalScale = 1f;
            Debug.Log("Change small scale for 1" + this);
        }
    }
}
