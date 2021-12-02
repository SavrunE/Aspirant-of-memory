using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NoOpenLevelViewer))]
public class LevelOpener : MonoBehaviour
{
    [SerializeField] private int payPrice;
    private Points points;
    private NoOpenLevelViewer noOpenLevelViewer;

    private static int openLevelsNumerator;

    public int PayPrice() => payPrice;

    private void Start()
    {
        points = transform.parent.parent.GetComponent<PointsContainer>().Points;
        Debug.Log(points);
    }

    public void TryPayToOpenLevel()
    {
        if (points.PointsCount >= payPrice)
        {
            points.PointsReduct(payPrice);

            OpenLevel();
        }
    }

    public void OpenLevel()
    {
        noOpenLevelViewer.GetComponent<NoOpenLevelViewer>();
        noOpenLevelViewer.OpenLevel();
    }
}
