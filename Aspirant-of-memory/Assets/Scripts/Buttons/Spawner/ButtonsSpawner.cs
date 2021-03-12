using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;


[RequireComponent(typeof(Sequence))]
public class ButtonsSpawner : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    [SerializeField] private int ButtonsCount;
    [SerializeField] private ButtonRotator buttonRotatorTemplate;
    private Sequence sequence;
    public List<Button> childButtons { get; private set; }

    public void OnSceneLoaded(LevelConfiguration argument)
    {
        ButtonsCount = argument.ButtonsCount;
    }

    public void Start()
    {
        sequence = GetComponent<Sequence>();

        childButtons = new List<Button>();
        ButtonRotator buttonRotator;
        float angelsSpawn = 360f / ButtonsCount;

        for (int i = 0; i < ButtonsCount; i++)
        {
            buttonRotator = Instantiate(buttonRotatorTemplate, this.transform);
            childButtons.Add(buttonRotator.GetComponentInChildren<Button>());

            buttonRotator.transform.eulerAngles = new Vector3(0, 0, angelsSpawn * i);
        }
        sequence.CollectSequence(childButtons);
    }
}