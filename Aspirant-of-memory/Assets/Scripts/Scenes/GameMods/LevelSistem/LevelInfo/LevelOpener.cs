using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NoOpenLevelViewer))]
public class LevelOpener : MonoBehaviour
{
    public int LevelNumber { get; private set; }
    public bool IsOpened { get; private set; } = false;

    [SerializeField] private int payPrice;
    
    private SaveSerial saveSerial;
    private Points points;
    private LevelSwitcher levelSwitcher;
    private NoOpenLevelViewer noOpenLevelViewer;

    public int PayPrice() => payPrice;

    public void SetLevelNumber(int level)
    {
        //Debug.Log(level);
        LevelNumber = level;
    }

    public void TryPayToOpenLevel()
    {
        LinksContainer linksContainer = transform.parent.parent.parent.GetComponent<LinksContainer>();
        points = linksContainer.Points;

        if (points.PointsCount >= payPrice)
        {
            Debug.Log(LevelNumber);
            points.PointsReduct(payPrice);
            saveSerial = linksContainer.SaveSerial;
            saveSerial.SaveParameters(points.PointsCount, LevelNumber);

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
