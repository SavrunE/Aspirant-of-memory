using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using IJunior.TypedScenes;
using System;

[RequireComponent(typeof(ButtonsSpawner))]
[RequireComponent(typeof(Sequence))]
public class SpinnerMover : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    [SerializeField] private int buttonsOffset;

    private ButtonsSpawner buttonsSpawner;
    private Sequence sequence;

    public event Action<bool> SequenceActivated;

    public void OnSceneLoaded(LevelConfiguration argument)
    {
        buttonsOffset = argument.RotateLength;
    }

    private void OnEnable()
    {
        buttonsSpawner = GetComponent<ButtonsSpawner>();
        sequence = GetComponent<Sequence>();

        sequence.QueueReady += DoRotate;
    }
    private void OnDisable()
    {
        sequence.QueueReady -= DoRotate;
    }

    public void DoRotate(bool activated)
    {
        if (activated && buttonsOffset != 0)
        {
            int range = UnityEngine.Random.Range(0, 2);
            switch (range)
            {
                case 0:
                    StartCoroutine(Rotate(buttonsSpawner.angleRotation * buttonsOffset));
                    break;
                case 1:
                    StartCoroutine(Rotate(-buttonsSpawner.angleRotation * buttonsOffset));
                    break;
            }
        }
        else
        {
            SequenceActivated?.Invoke(true);
        }
    }
    private IEnumerator Rotate(float valueZ)
    {
        transform.DORotate(new Vector3(0, 0, valueZ), sequence.movingDelay, RotateMode.Fast);
        yield return new WaitForSeconds(sequence.movingDelay);
        SequenceActivated?.Invoke(true);
    }
}
