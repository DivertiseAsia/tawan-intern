using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour, IDataPersistence
{
    [SerializeField] Currency[] currencyList;


    public void LoadData(GameData data)
    {
        foreach (Currency currency in currencyList)
        {
            if (data.currenciesName.Contains(currency.name))
            {
                int indexOfCurrency = data.currenciesName.IndexOf(currency.name);

                currency.amount = data.currenciesAmount[indexOfCurrency];
            }
            else
            {
                data.currenciesName.Add(currency.name);
                data.currenciesAmount.Add(currency.amount);
            }
        }
    }

    public void SaveData(GameData data)
    {
        foreach (Currency currency in currencyList)
        {
            if (data.currenciesName.Contains(currency.name))
            {
                int indexOfCurrency = data.currenciesName.IndexOf(currency.name);

                data.currenciesAmount[indexOfCurrency] = currency.amount;
            }
            else
            {
                data.currenciesName.Add(currency.name);
                data.currenciesAmount.Add(currency.amount);
            }
        }
    }

}
