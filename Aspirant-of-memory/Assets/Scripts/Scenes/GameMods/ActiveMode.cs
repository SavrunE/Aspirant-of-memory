using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveMode : MonoBehaviour
{
    private Mode mode;
    public Mode Mode() => mode;

    public void ChangeActiveMode(Mode mode)
    {
        this.mode = mode;
    }
}
