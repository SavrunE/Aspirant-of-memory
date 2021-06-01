using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private LevelLoader levelLoader;
    [SerializeField] private Text levelText;

    private void ChangeTextLevel(int value)
    {
        levelText.text = "Level " + value.ToString();
    }
}
