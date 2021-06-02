using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class NextModeAnimation : Animation
{
    private ParticleSystem nextModeEffect;

    private void Start()
    {
        nextModeEffect = gameObject.GetComponent<ParticleSystem>();
    }

    public void StartAnimation()
    {
        nextModeEffect.Play();
    }
}
