using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Sequence sequence;
    [SerializeField] private LevelConfiguration levelConfiguration;

    private void OnEnable()
    {
        sequence.SequenceChanged += OnSequenceChanged;
    }
    private void OnDisable()
    {
        sequence.SequenceChanged -= OnSequenceChanged;
    }

    private void OnSequenceChanged(int size)
    {
        if (size == 0)
        {
            DefaultLevel.Load(levelConfiguration);
        }
    }
}
