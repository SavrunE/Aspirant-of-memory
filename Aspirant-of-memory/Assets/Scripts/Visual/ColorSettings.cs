using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Sequence))]
public class ColorSettings : MonoBehaviour
{
    public Color[] colors;
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
            }
        }
    }
}
