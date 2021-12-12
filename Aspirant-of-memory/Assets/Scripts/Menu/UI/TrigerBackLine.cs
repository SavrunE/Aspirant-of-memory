using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerBackLine : MonoBehaviour
{
    [SerializeField] private BackGroundMover backGroundMoveSpawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<TrigerTopLine>(out TrigerTopLine triger))
        {
            Debug.Log("Here");
            triger.ChangeYBackground();
        }
    }
}
