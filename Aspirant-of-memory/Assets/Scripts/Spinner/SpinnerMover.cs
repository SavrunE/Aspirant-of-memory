using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(ButtonsSpawner))]
[RequireComponent(typeof(Sequence))]
public class SpinnerMover : MonoBehaviour
{
    [SerializeField] private int buttonsOffset;

    private ButtonsSpawner buttonsSpawner;
    private Sequence sequence;

    private void OnEnable()
    {
        buttonsSpawner = GetComponent<ButtonsSpawner>();
        sequence = GetComponent<Sequence>();

        sequence.SequenceActivated += DoRotate;
    }
    private void OnDisable()
    {
        sequence.SequenceActivated -= DoRotate;
    }

    public void DoRotate(bool activated)
    {
        if (activated)
        {
            int range = Random.Range(0, 2);
            switch (range)
            {
                case 0:
                    Rotate(buttonsSpawner.angleRotation * buttonsOffset);
                    break;
                case 1:
                    Rotate(-buttonsSpawner.angleRotation * buttonsOffset);
                    break;
            }
        }
    }
    private void Rotate(float valueZ)
    {
        transform.DORotate(new Vector3(0, 0, valueZ), sequence.movingDelay, RotateMode.Fast);
    }
}
