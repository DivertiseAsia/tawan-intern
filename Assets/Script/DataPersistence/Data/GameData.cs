using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int starAmount;
    public int diamondAmount;

    public GameData()
    {
        this.starAmount = 0;
        this.diamondAmount = 0;
    }
}
