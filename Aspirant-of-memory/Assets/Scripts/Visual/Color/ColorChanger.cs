using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorChanger : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    private float maximumEffectAlpha;
    private float speedEffectChanger;
    private float baseAlpha;

    private Coroutine coroutine = null;

    private void Start()
    {
        TakeColorSetiings();

        ChangeCollorAlpha();
    }
    private void TakeColorSetiings()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        maximumEffectAlpha = ColorSettings.Instance.maximumEffectAlpha;
        speedEffectChanger = ColorSettings.Instance.speedEffectChanger;
        baseAlpha = spriteRenderer.color.a;
    }

    public void ChangeBaseColor(int element)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = ColorSettings.Instance.colors[element];
    }

    public void ChangeBaseColor(int element, float colorAlpha)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = ColorSettings.Instance.colors[element];
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, colorAlpha);
    }

    public void ChangeCollorAlpha()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, baseAlpha);
        }
        coroutine = StartCoroutine(StartChangeColor());
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

        coroutine =  StartCoroutine(ReturnChangeColor());
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

        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, baseAlpha);
    }
}
