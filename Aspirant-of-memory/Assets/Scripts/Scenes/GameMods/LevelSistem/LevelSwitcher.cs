using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    private LevelOpen levelOpen;
    private LevelClose levelClose;

    private void OnEnable()
    {
        levelOpen = GetComponentInChildren<LevelOpen>();
        levelClose = GetComponentInChildren<LevelClose>();

        if (levelOpen == null || levelClose == null)
        {
            throw new System.NotFiniteNumberException();
        }

        levelOpen.gameObject.SetActive(false);
    }

    public void OpenLevel()
    {
        levelOpen.gameObject.SetActive(true);
        levelClose.gameObject.SetActive(false);
    }

    public void CloseLevel()
    {
        levelOpen.gameObject.SetActive(false);
        levelClose.gameObject.SetActive(true);
    }
}
