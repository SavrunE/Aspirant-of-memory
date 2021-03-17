using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorSettings : MonoBehaviour
{
    public static ColorSettings Instance;
    public Color[] colors;

    [Range(0f, 0.5f)]
    public float minimumEffectAlpha = 0.2f;
    [Range(0.6f, 0.9f)]
    public float maximumEffectAlpha = 0.9f;
    public float speedEffectChanger = 0.01f;
    public float effectAlpha = 0.2f;

    private Sequence sequence;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance == this)
        {
            Destroy(gameObject);
        }

        sequence = GetComponent<Sequence>();
    }
}
