using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Pool", menuName = "Pool")]
public class PoolScriptableObject : ScriptableObject
{
    public Sprite _currencySprite;
    public ItemScriptableObject[] items;
    public string bannerName;

    public ItemScriptableObject[] GetItemsList(RarityName rarity)
    {
        ItemScriptableObject[] selectedItems = Array.FindAll(items, item => item.rarity == rarity);

        return selectedItems;
    }
}
