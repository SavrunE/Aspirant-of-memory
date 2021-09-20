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

    private Mode gameMode;
    public Mode Mode => gameMode;

    private Points points;
    private SpinnerAnimation animation;

    private void Start()
    {
<<<<<<< HEAD
        gameMode = MySingleton.Instance.ActiveMode;
        Debug.Log(gameMode);
=======
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e
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
<<<<<<< HEAD
        gameMode.LevelComplete(modsContainer);
=======

        if (gameMode.ModeCompleted())
        {
            Mode nextMode = modsContainer.TakeNextMode(Mode);

            nextMode.NextLevelLoad();
        }
>>>>>>> c35f6241bd1faf1c1463ce2c185d51ce458a004e
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
