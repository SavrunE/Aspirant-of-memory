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
        sequence.LoseLevel += OnLoseLevel;
    }
    private void OnDisable()
    {
        sequence.LoseLevel -= OnLoseLevel;
    }

    private void OnSequenceChanged(int size)
    {
        if (size == 0)
        {
            Debug.Log("New level");
            //levelConfiguration.ChangeValues(1);
            DefaultLevel.Load(levelConfiguration);
        }
    }
    private void OnLoseLevel()
    {
        Debug.Log("Lose level");
        DefaultLevel.Load(levelConfiguration);
    }
}
