using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSettings : MonoBehaviour
{

    public Color[] colors;

    [Range(0f, 0.5f)]
    public float effectAlpha = 0.2f;
    [Range(0.6f, 0.9f)]
    public float maxEffectAlpha = 0.9f;
    public float speedEffectChanger = 0.01f;

    private Sequence sequence;

    private ColorSettings colorSettings;

    private void Start()
    {
        sequence = GetComponent<Sequence>();
        ChangeButtonsColor();
    }

    private void ChangeButtonsColor()
    {
        Debug.Log("Length " + sequence.childButtons.Length + " must be color changed");
    }
}
