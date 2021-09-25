using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using IJunior.TypedScenes;

public class Sequence : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    [SerializeField] private int queueLength;
    [SerializeField] private float activateButtonDelay = 1.5f;

    private List<Button> childButtons;
    private Queue<Button> queueButtons;
    private ButtonsSpawner buttonsSpawner;

    public float movingDelay = 1f; 

    public event Action<bool> QueueReady;
    public event Action<int> SequenceChanged;
    public event Action LoseLevel;
    public void OnSceneLoaded(LevelConfiguration argument)
    {
        queueLength = argument.QueueLength;
    }

    public void CollectSequence(List<Button> childButtons)
    {
        this.childButtons = childButtons;
        ChangeButtonsStartColor();
    }

    private void ChangeButtonsStartColor()
    {
        for (int i = 0; i < childButtons.Count; i++)
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

        for (int i = 0; i < queueLength; i++)
        {
            button = childButtons[UnityEngine.Random.Range(0, childButtons.Count)];
            queueButtons.Enqueue(button);
            button.PutInQueue();

            yield return new WaitForSeconds(activateButtonDelay);
        }
        QueueReady?.Invoke(true);
    }

    public void CheckButtonSelected(Button button)
    {
        if (queueButtons.Any() && button == queueButtons.Peek())
        {
            queueButtons.Dequeue();
            button.Activate();
            SequenceChanged?.Invoke(queueButtons.Count);
        }
        else
        {
            Debug.Log("Game was stopped by losing");
            QueueReady?.Invoke(false);
            LoseLevel?.Invoke();
        }
    }
}