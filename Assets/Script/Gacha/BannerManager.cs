using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BannerManager : MonoBehaviour
{
    public BannerType bannerType;
    public PoolScriptableObject[] pools;

    public ItemScriptableObject findItem(PoolScriptableObject pool, BannerType bannerType, ItemType type, RarityName rarity )
    {
        ItemScriptableObject selectedItem = Array.Find(pool.items, item => 
                                                            item.rarity == rarity &&
                                                            item.bannerType == bannerType &&
                                                            item.itemType == type);

        return selectedItem;
    }
}

public enum BannerType
{
    Standard,
    Limited
}