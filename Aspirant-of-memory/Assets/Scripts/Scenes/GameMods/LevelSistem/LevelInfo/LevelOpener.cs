using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NoOpenLevelViewer))]
public class LevelOpener : MonoBehaviour
{
    public bool IsOpened { get; private set; } = false;

    [SerializeField] private int payPrice;
   
    private Points points;
    private LevelSwitcher levelSwitcher;
    private NoOpenLevelViewer noOpenLevelViewer;

    private static int openLevelsNumerator;

    public int PayPrice() => payPrice;

    public void TryPayToOpenLevel()
    {
        points = transform.parent.parent.GetComponent<PointsContainer>().Points;

        if (points.PointsCount >= payPrice)
        {
            points.PointsReduct(payPrice);

            OpenLevel();
        }
        else
        {
            Debug.Log("Have no points");
        }
    }

    public void OpenLevel()
    {
        LevelSwitcherInitialization();
        levelSwitcher.OpenLevel();
    }

    public void CloseLevel()
    {
        LevelSwitcherInitialization();
        levelSwitcher.CloseLevel();
    }

    private void LevelSwitcherInitialization()
    {
        levelSwitcher = transform.parent.gameObject.GetComponent<LevelSwitcher>();
        if (levelSwitcher == null)
        {
            throw new System.NotFiniteNumberException();
        }
    }
}
