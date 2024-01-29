using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public List<string> currenciesName;
    public List<int> currenciesAmount;

    public GameData()
    {
        currenciesName = new List<string>();
        currenciesAmount = new List<int>();       
    }
}
