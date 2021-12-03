using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NoOpenLevelViewer))]
public class LevelOpener : MonoBehaviour
{
    public bool IsOpened { get; private set; } = false;

    [SerializeField] private int payPrice;
   
    private Points points;
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
    }

    public void OpenLevel()
    {
        
    }
}
