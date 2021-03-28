using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour
{
    [SerializeField] private ModeController modeController;
    private Mode mode;

    [SerializeField] private Text levelText;
    private int baseLevel = 0;

    private void OnEnable()
    {
        mode = modeController.TakeCurrentMode();
        ChangeTextLevel(mode.LevelNumber);
    }

    private void ChangeTextLevel(int value)
    {
        levelText.text = "Level " + value.ToString();
    }
}