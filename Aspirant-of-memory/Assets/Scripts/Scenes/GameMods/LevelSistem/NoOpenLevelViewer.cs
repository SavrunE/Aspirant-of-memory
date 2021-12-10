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

    private float smallestAlpha;

    public void ChangeView(float pointsSlashPayPrice, Color openTextColor, Color closeTextColor)
    {
        smallestAlpha = 0.3f;

        levelOpener = GetComponent<LevelOpener>();
        text = gameObject.GetComponentInChildren<Text>();
        text.text = levelOpener.PayPrice().ToString();
        ChangeColor(pointsSlashPayPrice, openTextColor, closeTextColor);
    }

    private void ChangeColor(float pointsSlashPayPrice, Color openTextColor, Color closeTextColor)
    {
        if (pointsSlashPayPrice >= 1f)
        {
            text.color = openTextColor;
            return;
        }
        if (pointsSlashPayPrice >= smallestAlpha)
        {
            text.color = new Color(closeTextColor.r, closeTextColor.g, closeTextColor.b, 1f * pointsSlashPayPrice);
        }
        else
        {
            text.color = new Color(closeTextColor.r, closeTextColor.g, closeTextColor.b, smallestAlpha);
        }
    }
}
