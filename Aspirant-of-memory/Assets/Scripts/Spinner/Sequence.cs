using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    [SerializeField] private int lengthQueue;
    [SerializeField] private float ActivateButtonDelay = 0.5f;

    public Button[] childButtons { get; private set; }
    private Queue<Button> queueButtons;

    private void Start()
    {
        childButtons = gameObject.GetComponentsInChildren<Button>();

        for (int i = 0; i < childButtons.Length; i++)
        {
            childButtons[i].TakeBaseColor(i);
        }

        queueButtons = new Queue<Button>();

        StartCoroutine(CollectQueue());
    }

    private IEnumerator CollectQueue()
    {
        Button button;
        for (int i = 0; i < lengthQueue; i++)
        {
            yield return new WaitForSeconds(ActivateButtonDelay);

            button = childButtons[Random.Range(0, childButtons.Length)];
            queueButtons.Enqueue(button);
            button.PutInQueue();
        }
        Debug.Log("Need to make it possible to start playing.");
    }

    public void CheckButtonSelected(Button button)
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
