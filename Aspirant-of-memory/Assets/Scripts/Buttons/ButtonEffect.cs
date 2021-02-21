using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour, IButtonEffect
{
    public Button buttonParent;

    [SerializeField] private float maxAlpha = 0.9f;
    [SerializeField] private float speedEffect = 0.01f;

    private SpriteRenderer sprite;
    private float baseAlpha;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        baseAlpha = sprite.color.a;
    }

    public void OnClick() 
    {
        buttonParent.OnClick();
    }

    public void ChangeCollor()
    {
        StartCoroutine(StartChangeColor());
    }

    private IEnumerator StartChangeColor()
    {
        while (sprite.color.a < maxAlpha)
        {
            sprite.color = Color.Lerp(sprite.color,
                       new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1),
                       speedEffect);
            yield return new WaitForFixedUpdate();
        }

        Debug.Log("sprite.color.a < maxAlpha");

        StartCoroutine(ReturnChangeColor());
    }

    private IEnumerator ReturnChangeColor()
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
