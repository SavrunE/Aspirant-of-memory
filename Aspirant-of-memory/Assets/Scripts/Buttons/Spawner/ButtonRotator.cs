using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRotator : MonoBehaviour
{
    public Sequence sequence;

    private void Start()
    {
        sequence = transform.parent.GetComponent<Sequence>();
    }
}
