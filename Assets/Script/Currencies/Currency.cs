using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Currency", menuName = "Currency")]
public class Currency : ScriptableObject
{
    public Sprite sprite;
    public string currencyName;
    public int amount;

    public void Pay(int price)
    {
        if (amount >= price)
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

    public bool IsCurrencyEnough(int price)
    {
        return amount >= price;
    }
}
