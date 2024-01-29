using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int starAmount;
    public int diamondAmount;

    public List<string> currenciesName;
    public List<int> currenciesAmount;

    public GameData()
    {
        this.starAmount = 0;
        this.diamondAmount = 0;

        currenciesName = new List<string>();
        currenciesAmount = new List<int>();       
    }
}
