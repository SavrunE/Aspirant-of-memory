using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ModsContainer))]
[RequireComponent(typeof(Points))]
[RequireComponent(typeof(Animation))]
public class LevelLoader : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    [SerializeField] private Sequence sequence;
    [SerializeField] private LevelConfiguration levelConfiguration;

    private Mode gameMode;

    private ModsContainer modsContainer;
    private Points points;
    private Animation animation;

    private void Start()
    {
        modsContainer = GetComponent<ModsContainer>();
        points = GetComponent<Points>();
        animation = GetComponent<Animation>();
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
    public void OnSceneLoaded(LevelConfiguration argument)
    {
        gameMode = argument.Mode;
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
        StartCoroutine(WinCoroutine());
    }

    private IEnumerator WinCoroutine()
    {
        float waintTime = animation.WinAnimation();
        yield return new WaitForSeconds(waintTime);

        points.PointsIncrease(gameMode.PointsFromWin);
        gameMode.LevelComplete(modsContainer);
    }

    private void LoseLevel()
    {
        StartCoroutine(LoseCoroutine());
    }
    private IEnumerator LoseCoroutine()
    {
        float waintTime = animation.LoseAnimation();
        yield return new WaitForSeconds(waintTime);

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
