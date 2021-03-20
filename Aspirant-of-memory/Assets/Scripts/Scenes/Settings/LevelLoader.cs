using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Sequence sequence;
    [SerializeField] private LevelConfiguration levelConfiguration;
    [SerializeField] private Mode gameMode;

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
            gameMode.NextLevelLoad();
        }
    }
    private void OnLoseLevel()
    {
        Debug.Log("Lose level");
        gameMode.RestartLevel();
    }
}
