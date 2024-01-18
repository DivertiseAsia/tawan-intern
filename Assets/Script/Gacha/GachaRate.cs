using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GachaRate
{
    public RarityName rarityName;

    [Range(1,100)]
    public float rate;
}
