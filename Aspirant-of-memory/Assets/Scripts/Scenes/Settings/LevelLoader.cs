using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Points))]
[RequireComponent(typeof(SpinnerAnimation))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField] private Sequence sequence;
    [SerializeField] private ActiveLevelConfiguration activeLevelConfiguration;
    [SerializeField] private LevelConfiguration levelConfiguration;
    
    private StageLevelChanger stageLevelChanger;
    private Points points;
    private SpinnerAnimation spinnerAnimation;

    public StageLevelChanger Mode => stageLevelChanger;
    
    //public void OnSceneLoaded(LevelConfiguration argument)
    //{
    //    levelConfiguration = argument;
    //}

    private void Awake()
    {
        stageLevelChanger = GetComponent<StageLevelChanger>();
        stageLevelChanger.ChangeActiveLevelConfiguration(activeLevelConfiguration);
        stageLevelChanger.ChangeLevelConfigurationParametes(activeLevelConfiguration.Parameters);
    }

    private void Start()
    {
        points = GetComponent<Points>();
        spinnerAnimation = GetComponent<SpinnerAnimation>();
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
        float waitTime = spinnerAnimation.WinAnimation();
        yield return new WaitForSeconds(waitTime);

        points.PointsIncrease(stageLevelChanger.PointsAfterWinStageLevel);
        stageLevelChanger.StageLevelComplete();
    }

    private void LoseLevel()
    {
        StartCoroutine(LoseCoroutine());
    }

    private IEnumerator LoseCoroutine()
    {
        float waitTime = spinnerAnimation.LoseAnimation();
        yield return new WaitForSeconds(waitTime);

        stageLevelChanger.RestartLevel();
    }

    public void ModeRefundLevelSettings()
    {
        stageLevelChanger.RefundLevelSettings();
    }
}