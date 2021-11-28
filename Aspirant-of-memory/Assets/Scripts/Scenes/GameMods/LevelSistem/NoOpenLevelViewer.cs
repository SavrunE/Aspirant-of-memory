using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        }
    }
}
