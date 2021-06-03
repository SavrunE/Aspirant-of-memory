using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMode : MonoBehaviour
{
    private ModeContainer mode;
    public ModeContainer Mode() => mode;

    public void ChangeActiveMode(ModeContainer mode)
    {
        this.mode = mode;
    }
}
