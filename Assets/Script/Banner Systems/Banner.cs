using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Banner : ScriptableObject
{
    public string bannerName;
    public BannerType bannerType;
    public Currency _currency;
    public ItemScriptableObject[] bannerItems;
    public ItemScriptableObject[] poolItems;

    public int legendaryWishCount;
    public float defaultLegendaryRate;

    public bool limitedGuaranty = false;
    public bool legendaryGuaranty = false;

    public ItemScriptableObject GetItems(Rarity rarity)
    {
        ItemScriptableObject resultItem;

        if (rarity == Rarity.Legendary)
        {
            resultItem = GetLegendaryItem();
            SetLimitedGuaranty(resultItem);

            return resultItem;
        }

        ItemScriptableObject[] selectedItems = Array.FindAll(poolItems, item => item.rarity == rarity);

        int random = UnityEngine.Random.Range(0, selectedItems.Length);
        resultItem = selectedItems[random];

        return resultItem;
    }

    public void UpdateLegendaryCount(Rarity rarity)
    {
        if(rarity == Rarity.Legendary && !legendaryGuaranty)
        {
            legendaryWishCount = 0;
        }
        else
        {
            legendaryWishCount++;
        }
    }

    public void SetLegendaryGuaranty(int wishesToGuaranty, GachaRate legendaryRate)
    {
        if (legendaryWishCount == (wishesToGuaranty - 1))
        {
            Debug.Log("Guaranty");
            defaultLegendaryRate = legendaryRate.rate;
            legendaryRate.rate = 100;
            legendaryGuaranty = true;
        }
        else if (legendaryWishCount == wishesToGuaranty && legendaryGuaranty)
        {
            legendaryWishCount = 0;
            legendaryRate.rate = defaultLegendaryRate;
            legendaryGuaranty = false;
        }
    }

    public ItemScriptableObject findItem(ItemType type, Rarity rarity)
    {
        ItemScriptableObject selectedItem = Array.Find(bannerItems, item =>
                                                            item.rarity == rarity &&
                                                            item.bannerType == bannerType &&
                                                            item.itemType == type);

        return selectedItem;
    }

    public abstract void SetupPool();

    public abstract void SetLimitedGuaranty(ItemScriptableObject resultItem);

    public abstract ItemScriptableObject GetLegendaryItem();


}

public enum BannerType
{
    Standard,
    Limited
}