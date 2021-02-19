using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : MonoBehaviour
{
    [SerializeField] private int lengthQueue;

    private MainButton[] childButtons;
    private Queue<MainButton> queueButtons;

    private void Start()
    {
        childButtons = gameObject.GetComponentsInChildren<MainButton>();
        foreach (var child in childButtons)
        {

            Debug.Log(child);
        }
        queueButtons = new Queue<MainButton>();

        CollectQueue();
    }

    private void CollectQueue()
    {
        for (int i = 0; i < lengthQueue; i++)
        {
            queueButtons.Enqueue(childButtons[Random.Range(0, childButtons.Length)]);

            Debug.Log(childButtons[Random.Range(0, childButtons.Length)]);
        }
    }
}
