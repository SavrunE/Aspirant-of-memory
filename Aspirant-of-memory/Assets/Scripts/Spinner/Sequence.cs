using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    [SerializeField] private int lengthQueue;
    [SerializeField] private float ActivateButtonDelay = 1.5f;

    public Button[] childButtons { get; private set; }
    private Queue<Button> queueButtons;

    private void Start()
    {
        childButtons = gameObject.GetComponentsInChildren<Button>();
        ChangeButtonsStartColor();
    }

    private void ChangeButtonsStartColor()
    {
        for (int i = 0; i < childButtons.Length; i++)
        {
            childButtons[i].TakeBaseColor(i);
        }
    }

    public void StartCollectQueue()
    {
        StartCoroutine(CollectQueue());
    }

    private IEnumerator CollectQueue()
    {
        queueButtons = new Queue<Button>();

        Button button;

        for (int i = 0; i < lengthQueue; i++)
        {
            button = childButtons[Random.Range(0, childButtons.Length)];
            queueButtons.Enqueue(button);
            button.PutInQueue();

            yield return new WaitForSeconds(ActivateButtonDelay);
        }
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
