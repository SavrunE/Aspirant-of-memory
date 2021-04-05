using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModsContainer))]
[RequireComponent(typeof(Points))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Sequence sequence;
    [SerializeField] private LevelConfiguration levelConfiguration;

    private Mode gameMode;

    private ModsContainer modsContainer;
    private Points points;

    private void Start()
    {
        points = GetComponent<Points>();
        modsContainer = GetComponent<ModsContainer>();
    }
    private void OnEnable()
    {
        sequence.SequenceChanged += OnSequenceChanged;
        sequence.LoseLevel += LoseLevel;
    }
    private void OnDisable()
    {
        sequence.SequenceChanged -= OnSequenceChanged;
        sequence.LoseLevel -= LoseLevel;
    }

    private void OnSequenceChanged(int size)
    {
        if (size == 0)
        {
            WinLevel();
        }
    }

    private void WinLevel()
    {
        points.PointsIncrease(gameMode.PointsFromWin);
        gameMode.LevelComplete(modsContainer);
    }

    private void LoseLevel()
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
