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

    private Text text;

    private void Start()
    {
        levelOpener = GetComponent<LevelOpener>();
        text = gameObject.GetComponentInChildren<Text>();
        text.text = levelOpener.PayPrice().ToString();
    }
}
