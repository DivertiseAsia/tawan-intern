using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "new Banner", menuName = "Banner")]
public class BannerScriptableObject : ScriptableObject
{
    public Sprite _currencySprite;
    public ItemScriptableObject[] items;
    public string bannerName;
    public BannerType bannerType;

    public ItemScriptableObject[] GetItemsList(RarityName rarity)
    {
        ItemScriptableObject[] selectedItems = Array.FindAll(items, item => item.rarity == rarity);

        return selectedItems;
    }
}
