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
    [SerializeField] private SaveSerial saveSerial;

    private StageLevelChanger stageLevelChanger;
    private Points points;
    private SpinnerAnimation spinnerAnimation;

    public StageLevelChanger Mode => stageLevelChanger;

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
        LoadProgress();
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

    public void LoadProgress()
    {
        saveSerial = GetComponent<SaveSerial>();
        saveSerial.LoadGame();
        points.ChangePointsView(saveSerial.PointsCurrentValue);
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


        if (activeLevelConfiguration.StageLevelNumberInfo() >= activeLevelConfiguration.MaxStageLevelNumberInfo())
        {
            points.PointsIncrease(activeLevelConfiguration.PointsAfterEndLevel);
            Debug.Log("Win and load start window");
            LoadStartWindow();
        }
        else
        {
            points.PointsIncrease(activeLevelConfiguration.PointsAfterWinStageLevel);
            stageLevelChanger.NextStageLevelLoad();
        }
    }

    public void LoadStartWindow()
    {
        StartWindow.Load();
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