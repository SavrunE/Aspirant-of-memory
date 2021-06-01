using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextModeAnimation : Animation
{
    [SerializeField] private ParticleSystem nextModeEffect;

    public void StartAnimation()
    {
        nextModeEffect.Play();
    }
}
