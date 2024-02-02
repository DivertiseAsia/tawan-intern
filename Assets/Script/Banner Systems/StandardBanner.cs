using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Standard Banner", menuName = "Banner/Standard Banner", order = 0)]
public class StandardBanner : Banner
{

    private void Reset()
    {
        bannerType = BannerType.Standard;
    }

    public override void SetupPool()
    {
        poolItems = bannerItems;
    }
    public override ItemScriptableObject GetLegendaryItem()
    {
        ItemScriptableObject[] selectedItems = Array.FindAll(bannerItems, item => item.rarity == Rarity.Legendary);

        int random = UnityEngine.Random.Range(0, selectedItems.Length);
        ItemScriptableObject resultItem = selectedItems[random];

        return resultItem;
    }


    public override void SetLimitedGuaranty(ItemScriptableObject resultItem)
    {
        limitedGuaranty = false;
    }

}
