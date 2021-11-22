using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private int value = 2;
    private int castNumberA = 0;
    private int castNumberB = 0;
    System.Random rnd;

    public int Acheck;

    public int Bcheck;

    private float winPoint;
    private float losePoint;

    private void Start()
    {
        rnd = new System.Random();
    }
    public void Checker()
    {
        for (int i = 0; i < 1000; i++)
        {
            HardCheck();
        }
        Debug.Log(ViewEndResult());
    }

    private string ViewEndResult()
    {
        string result = "количество побед в процентах " + winPoint / (losePoint + winPoint) * 100;
        return result;
    }
    private void BaseCheck()
    {
        value = 2;

        int check1 = Randomizer(value);
        int check2 = Randomizer(value);

        if (check1 == check2)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }
    private void HardCheck()
    {
        int goodNumberA = 0;
        goodNumberA = HardCheckA();

        int goodNumberB = 0;
        goodNumberB = HardCheckB();
        if (goodNumberB == goodNumberA)
        {
            Win();
        }
        else
        {
            CheckWinner();
        }
    }
    private int HardCheckA()
    {
        castNumberA = 0;
        RandomizerA();

        while (Acheck != 0)
        {
            castNumberA++;
            RandomizerA();
        }
        return castNumberA;
    }
    private int HardCheckB()
    {
        castNumberB = 0;
        RandomizerB();

        while (Bcheck != 0)
        {
            castNumberB++;
            RandomizerB();
        }
        return castNumberB;
    }

    private void CheckWinner()
    {
        Randomizer();
        if (Acheck == Bcheck)
        {
            Win();
        }
        else
        {
            Lose();
        }
    }
    public void RandomizerA()
    {
        Acheck = Randomizer(value);
    }
    public void RandomizerB()
    {
        Bcheck = RandomizerSystem(value);
    }
    public void Randomizer()
    {
        Acheck = Randomizer(value);

        Bcheck = RandomizerSystem(value);
    }
    private int Randomizer(int value)
    {
        int chance = Random.Range(0, value);
        return chance;
    }
    private int RandomizerSystem(int value)
    {
        int chance = rnd.Next(0, value);
        return chance;
    }
    private void Win()
    {
        winPoint++;
        Debug.Log("Win");
    }
    private void Lose()
    {
        losePoint++;
        Debug.Log("Lose");
    }
}
