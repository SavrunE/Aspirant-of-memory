using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Sequence))]
public class ButtonsSpawner : MonoBehaviour
{
    [SerializeField] private int startButtonsCount;
    [SerializeField] private float localPositionY = 2f;
    [SerializeField] private ButtonRotator buttonRotatorTemplate;
    private Sequence sequence;
    public List<Button> childButtons { get; private set; }

    public void Start()
    {
        sequence = GetComponent<Sequence>();

        childButtons = new List<Button>();
        ButtonRotator buttonRotator;
        float angelsSpawn = 360f / startButtonsCount;

        for (int i = 0; i < startButtonsCount; i++)
        {
            buttonRotator = Instantiate(buttonRotatorTemplate, this.transform);
            childButtons.Add(buttonRotator.GetComponentInChildren<Button>());

            buttonRotator.transform.eulerAngles = new Vector3(0, 0, angelsSpawn * i);
            buttonRotator.transform.localPosition = new Vector3(0, localPositionY, 0);
        }
        Debug.Log(childButtons.Count);
        sequence.CollectSequence(childButtons);
    }
}