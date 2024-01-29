using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Currencies
{
    public Sprite sprite;
    public string name;
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

    public void Pay(int price)
    {
        if(amount >= price) 
        {
            amount -= price;
        }
        else
        {
            Debug.Log("Currency is not Enough!");
        }
    }

    public void Topup(int amount)
    {
        this.amount += amount;
    }
}
