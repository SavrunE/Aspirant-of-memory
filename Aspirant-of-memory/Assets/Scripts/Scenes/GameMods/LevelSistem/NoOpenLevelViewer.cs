using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


[RequireComponent(typeof(LevelOpener))]
public class NoOpenLevelViewer : MonoBehaviour
{
    [SerializeField] private Sprite CloseImageSprite;
    private LevelOpener levelOpener;

    private Image image;
    private Text text;

    private void Awake()
    {
        levelOpener = GetComponent<LevelOpener>();

        image = GetComponent<Image>();
        text = gameObject.GetComponentInChildren<Text>();
        //if level is NOT open
        if (true)
        {
            image.sprite = CloseImageSprite;
            //Text how many must pay to open
            text.text = levelOpener.PayPrice().ToString();
            SetRotateTextZ(45);
        }
    }

    private void SetRotateTextZ(int angle)
    {
        text.transform.DORotate(new Vector3(0, 0, angle), 0, RotateMode.Fast);
    }
}
