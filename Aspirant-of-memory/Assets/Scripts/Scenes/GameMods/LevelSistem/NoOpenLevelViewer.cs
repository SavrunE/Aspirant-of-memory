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

    private Sprite startSprite;
    private Text startText;

    private Image image;
    private Text text;
    private void Start()
    {
        levelOpener = GetComponent<LevelOpener>();
        startSprite = transform.GetComponent<Image>().sprite;
        startText = transform.GetComponentInChildren<Text>();

        image = GetComponent<Image>();
        text = gameObject.GetComponentInChildren<Text>();
        Debug.Log(text);
        //if level is NOT open
        if (true)
        {
            image.sprite = CloseImageSprite;
            //Text how many must pay to open
            text.text = levelOpener.PayPrice().ToString();
            text.transform.DORotate(new Vector3(0,0,45),0,RotateMode.Fast);
        }
    }

    public void OpenLevel()
    {
        image.sprite = startSprite;
        text.text = startText.text;
    }
}
