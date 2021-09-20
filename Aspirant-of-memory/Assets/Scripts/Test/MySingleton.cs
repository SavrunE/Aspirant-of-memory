using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton : Singleton<MySingleton>
{
    // (Optional) Prevent non-singleton constructor use.
    protected MySingleton() { }

    // Then add whatever code to the class you need as you normally would.
    public string MyTestString = "Hello world!";


    public Mode ActiveMode;
    public ModesContainer ModesContainer;
}