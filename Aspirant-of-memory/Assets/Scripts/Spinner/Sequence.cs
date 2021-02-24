using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ColorSettings))]
public class Sequence : MonoBehaviour
{
    public Buttons[] childButtons { get; private set; }

    [SerializeField] private int lengthQueue;
    [SerializeField] private float ActivateButtonDelay = 0.5f;

    private Queue<Buttons> queueButtons;
    private ColorSettings colorSettings;


    private void Awake()
    {
        colorSettings = GetComponent<ColorSettings>();
        childButtons = gameObject.GetComponentsInChildren<Buttons>();
        for (int i = 0; i < childButtons.Length; i++)
        {
            //childButtons[i].gameObject.GetComponent<SpriteRenderer>().color = colorSettings.colors[i];
        }
        queueButtons = new Queue<Buttons>();

        StartCoroutine(CollectQueue());
    }

    private IEnumerator CollectQueue()
    {
        Buttons button;
        for (int i = 0; i < lengthQueue; i++)
        {
            yield return new WaitForSeconds(ActivateButtonDelay);

            button = childButtons[Random.Range(0, childButtons.Length)];
            queueButtons.Enqueue(button);
            button.PutInQueue();
        }
        Debug.Log("Need to make it possible to start playing.");
    }

    public void CheckButtonSelected(Buttons button)
    {
        if (button == queueButtons.Peek())
        {
            queueButtons.Dequeue();
            button.Activate();
        }
        else
        {
            Debug.Log("Stop game");
        }
    }
}
