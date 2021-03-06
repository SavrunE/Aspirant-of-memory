using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Points))]
[RequireComponent(typeof(SpinnerAnimation))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Sequence sequence;
    [SerializeField] private LevelConfiguration levelConfiguration;
    [SerializeField] private ModesContainer modsContainer;

    private ModeContainer gameMode;
    public ModeContainer Mode => gameMode;

    private Points points;
    private SpinnerAnimation animation;



    private void Start()
    {
        gameMode = MySingleton.Instance.ModesContainer.ActiveMode;
        Debug.Log(gameMode);
        points = GetComponent<Points>();
        animation = GetComponent<SpinnerAnimation>();
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
        StartCoroutine(WinCoroutine());
    }

    private IEnumerator WinCoroutine()
    {
        float waintTime = animation.WinAnimation();
        yield return new WaitForSeconds(waintTime);

        points.PointsIncrease(gameMode.PointsFromWin);

        if (gameMode.ModeCompleted())
        {
            ModeContainer nextMode = modsContainer.TakeNextMode(Mode);

            nextMode.NextLevelLoad();
        }
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


    public void ModeRefundLevelSettings()
    {
        gameMode.RefundLevelSettings();
    }
}
