using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sequence))]
public class ColorSettings : MonoBehaviour
{
    public Color[] colors;

    [Range(0f, 0.5f)]
    public float effectAlpha = 0.2f;
    [Range(0.6f, 0.9f)]
    public float maxEffectAlpha = 0.9f;
    public float speedEffectChanger = 0.01f;

    private Sequence sequence;

    private void Start()
    {
        sequence = GetComponent<Sequence>();
        ChangeButtonsColor();
    }

    private void ChangeButtonsColor()
    {
        Debug.Log(sequence.childButtons.Length);
        for (int i = 0; i < sequence.childButtons.Length; i++)
        {
            if (sequence.childButtons[i].TryGetComponent(out Button button))
            {
                button.gameObject.GetComponent<SpriteRenderer>().color = colors[i];
                button.Effect.GetComponent<SpriteRenderer>().color = colors[i];
            }
        }
    }
}
