using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float normalScale;
    public float NormalScale => normalScale;
    private void Start()
    {
        if (normalScale < 0.1f)
        {
            Debug.Log("Scale so small" + this);
        }
    }
}
