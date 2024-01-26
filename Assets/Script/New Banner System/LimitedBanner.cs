using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Limited Banner", menuName = "Banner/Limited Banner", order = 1)]
public class LimitedBanner : Banner
{
    [SerializeField] private StandardBanner standardBanner;
    public override void SetupPool()
    {
        poolItems = new ItemScriptableObject[bannerItems.Length + standardBanner.bannerItems.Length];

        bannerItems.CopyTo(poolItems, 0);
        standardBanner.bannerItems.CopyTo(poolItems, bannerItems.Length);
    }

    public override ItemScriptableObject GetLegendaryItem()
    {
        ItemScriptableObject[] pool;

        pool = limitedGuaranty ? bannerItems : poolItems;

        ItemScriptableObject[] selectedItems = Array.FindAll(pool, item => item.rarity == RarityName.Legendary);

        int random = UnityEngine.Random.Range(0, selectedItems.Length);
        ItemScriptableObject resultItem = selectedItems[random];

        return resultItem;
    }


    public override void SetLimitedGuaranty(ItemScriptableObject resultItem)
    {
        limitedGuaranty = bannerItems.Contains(resultItem) ? false : true;
    }
}
