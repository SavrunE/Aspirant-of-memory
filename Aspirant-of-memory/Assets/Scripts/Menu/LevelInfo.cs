using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelInfo : MonoBehaviour, ISceneLoadHandler<LevelConfiguration>
{
    private Mode mode;
    [SerializeField] private Text levelText;
    private int baseLevel = 0;

    public void OnSceneLoaded(LevelConfiguration argument)
    {
        mode = argument.Mode;
        ChangeTextLevel(mode.LevelNumber);
    }

    private void ChangeTextLevel(int value)
    {
        levelText.text = "Level " + value.ToString();
    }
}
