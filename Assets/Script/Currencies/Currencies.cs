using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Currencies
{
    public int amount;

    public void DecreaseAmount(int num)
    {
        if (amount > 0)
        {
            amount -= num;
        }
    }

    public void IncreaseAmount(int num)
    {
        if (amount >= 0)
        {
            amount += num;
        }
    }
}
