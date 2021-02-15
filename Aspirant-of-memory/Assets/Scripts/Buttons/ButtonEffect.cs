using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEffect : MonoBehaviour, IButtonEffect
{
    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Activate() 
    {
        Debug.Log("Activated");
        sprite.color = Color.Lerp(sprite.color, 
            new Color(sprite.color.r, sprite.color.g, sprite.color.b, 255), 
            0.001f);
        
    }
}
