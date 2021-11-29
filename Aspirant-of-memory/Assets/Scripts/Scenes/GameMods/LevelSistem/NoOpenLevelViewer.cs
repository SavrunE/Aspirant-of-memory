using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class NoOpenLevelViewer : MonoBehaviour
{
    [SerializeField] private Sprite CloseImageSprite;
    private Image image;
    private Text text;
    private void Start()
    {
        image = GetComponent<Image>();
        text = gameObject.GetComponentInChildren<Text>();
        Debug.Log(text);
        //if level is NOT open
        if (true)
        {
            image.sprite = CloseImageSprite;
            //Text how many must pay to open
            text.text = "sad";
            text.transform.DORotate(new Vector3(0,0,45),0,RotateMode.Fast);
        }
    }
}
