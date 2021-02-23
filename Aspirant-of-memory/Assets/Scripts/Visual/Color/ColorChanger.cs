using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ButtonEffect))]
public class ColorChanger : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private ButtonEffect buttonEffect;
    private ColorSettings colorSettings;
    private float baseAlpha;
    private float maxAlpha;
    private float speedEffect;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        baseAlpha = spriteRenderer.color.a;
        buttonEffect = GetComponent<ButtonEffect>();
        colorSettings = buttonEffect.buttonParent.Queue.GetComponent<ColorSettings>();
        maxAlpha = colorSettings.maxEffectAlpha;
        speedEffect = colorSettings.speedEffectChanger;
    }
    public void ChangeCollor()
    {
        StartCoroutine(StartChangeColor(spriteRenderer));
    }

    private IEnumerator StartChangeColor(SpriteRenderer sprite)
    {
        while (sprite.color.a < maxAlpha)
        {
            sprite.color = Color.Lerp(sprite.color,
                       new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1),
                       speedEffect);
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("sprite.color.a < maxAlpha");

        StartCoroutine(ReturnChangeColor(sprite));
    }

    private IEnumerator ReturnChangeColor(SpriteRenderer sprite)
    {
        while (sprite.color.a > baseAlpha)
        {
            sprite.color = Color.Lerp(sprite.color,
                       new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0),
                       speedEffect);
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("sprite.color.a < maxAlpha");

        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, baseAlpha);
        yield return null;
    }
}
