using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModsContainer))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Sequence sequence;
    [SerializeField] private LevelConfiguration levelConfiguration;
    [HideInInspector]
    [SerializeField] private Mode gameMode;

    private void OnEnable()
    {
        sequence.SequenceChanged += OnSequenceChanged;
        sequence.LoseLevel += OnLoseLevel;
    }
    private void OnDisable()
    {
        sequence.SequenceChanged -= OnSequenceChanged;
        sequence.LoseLevel -= OnLoseLevel;
    }

    private void OnSequenceChanged(int size)
    {
        if (size == 0)
        {
            //Debug.Log("New level");
            gameMode.NextLevelLoad();
        }
    }
    private void OnLoseLevel()
    {
        //Debug.Log("Lose level");
        gameMode.RestartLevel();
    }

    public void SetActiveMode(Mode mode)
    {
        gameMode = mode;
    }

    public void ModeRefundLevelSettings()
    {
        gameMode.RefundLevelSettings();
    }
}
