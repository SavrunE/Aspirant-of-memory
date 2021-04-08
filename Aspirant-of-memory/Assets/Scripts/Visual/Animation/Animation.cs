using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Animation : MonoBehaviour
{
    [SerializeField] private Spinner spinner;
    [SerializeField] private float animationTime = 1f;
    [Range(1f, 5f)]
    [SerializeField] private float winAnimationMultiplayer = 1.5f;
    [SerializeField] private float maximalScale = 10f;
    [SerializeField] private float lowestScale = 0f;
    [SerializeField] private float rotateValue = 300f;

    private void Start()
    {
        StartLevelAnimation();
    }
    public float WinAnimation()
    {
        spinner.transform.DOScale(maximalScale, animationTime * winAnimationMultiplayer);
        spinner.transform.DORotate(new Vector3(0, 0, rotateValue), animationTime);

        return animationTime;
    }

    public float LoseAnimation()
    {
        spinner.transform.DOScale(lowestScale, animationTime);
        spinner.transform.DORotate(new Vector3(0, 0, rotateValue), animationTime);

        return animationTime;
    }

    public void StartLevelAnimation()
    {
        spinner.transform.localScale = new Vector3(lowestScale, lowestScale, lowestScale);
        spinner.transform.DOScale(spinner.NormalScale, animationTime);
    }
}
