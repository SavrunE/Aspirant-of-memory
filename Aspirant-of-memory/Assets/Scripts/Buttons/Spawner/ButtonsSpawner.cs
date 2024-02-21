using System.Collections.Generic;
using UnityEngine;
using IJunior.TypedScenes;

[RequireComponent(typeof(Sequence))]
public class ButtonsSpawner : MonoBehaviour, ISceneLoadHandler<ActiveLevelConfiguration>
{
    [SerializeField] private int ButtonsCount;
    [SerializeField] private ButtonRotator buttonRotatorTemplate;
    [SerializeField] private float buttonRadius = 1f;
    [SerializeField] private float buttonScale= 1f;
    private Sequence sequence;

    public float angleRotation => 360f / ButtonsCount;
    public List<Button> childButtons { get; private set; }

    public void OnSceneLoaded(ActiveLevelConfiguration argument)
    {
        ButtonsCount = argument.ButtonsCount;
    }

    public void Start()
    {
        sequence = GetComponent<Sequence>();

        childButtons = new List<Button>();
        ButtonRotator buttonRotator;

        for (int i = 0; i < ButtonsCount; i++)
        {
            buttonRotator = Instantiate(buttonRotatorTemplate, this.transform);
            childButtons.Add(buttonRotator.GetComponentInChildren<Button>());

			buttonRotator.SetRadiusScale(buttonRadius, buttonScale);
			buttonRotator.transform.eulerAngles = new Vector3(0, 0, angleRotation * i);

		}
        sequence.CollectSequence(childButtons);
    }
}