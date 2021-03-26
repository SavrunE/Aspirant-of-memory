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
    private ModsContainer modsContainer;

    private void Start()
    {
        modsContainer = GetComponent<ModsContainer>();
    }
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
            gameMode.LevelComplete(modsContainer);
        }
    }
    private void OnLoseLevel()
    {
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
