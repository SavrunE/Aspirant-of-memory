using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorChanger : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    private float minimumEffectAlpha;
    private float maximumEffectAlpha;
    private float speedEffectChanger;
    private float baseAlpha;

    private void Start()
    {
        TakeColorSetiings();

        ChangeCollorAlpha();
    }
    private void TakeColorSetiings()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        minimumEffectAlpha = ColorSettings.Instance.minimumEffectAlpha;
        maximumEffectAlpha = ColorSettings.Instance.maximumEffectAlpha;
        speedEffectChanger = ColorSettings.Instance.speedEffectChanger;
        baseAlpha = spriteRenderer.color.a;

        Debug.Log(minimumEffectAlpha + "" + maximumEffectAlpha + speedEffectChanger);
    }

    public void ChangeBaseColor(int element)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = ColorSettings.Instance.colors[element];
    }

    public void ChangeCollorAlpha()
    {
        StartCoroutine(StartChangeColor());
    }

    private IEnumerator StartChangeColor()
    {
        while (spriteRenderer.color.a < maximumEffectAlpha)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color,
                       new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1),
                       speedEffectChanger);
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("sprite.color.a < maxAlpha");

        StartCoroutine(ReturnChangeColor());
    }

    private IEnumerator ReturnChangeColor()
    {
        while (spriteRenderer.color.a > baseAlpha)
        {
            spriteRenderer.color = Color.Lerp(spriteRenderer.color,
                       new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0),
                       speedEffectChanger);
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("sprite.color.a < maxAlpha");

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, baseAlpha);
    }
}
