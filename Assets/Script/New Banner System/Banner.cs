using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Banner : ScriptableObject
{
    public string bannerName;
    public BannerType bannerType;
    public Sprite _currencySprite;
    public ItemScriptableObject[] bannerItems;
    public ItemScriptableObject[] poolItems;

    public int legendaryWishCount;
    public float defaultLegendaryRate;

    public bool limitedGuaranty;

    public ItemScriptableObject GetItems(RarityName rarity)
    {
        ItemScriptableObject resultItem;

        if (rarity == RarityName.Legendary)
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

    public void IncreaseLegendaryCount()
    {
        legendaryWishCount++;
    }

    public void SetLegendaryGuaranty(int legendaryGuaranty, GachaRate legendaryRate)
    {
        if (legendaryWishCount == (legendaryGuaranty - 1))
        {
            defaultLegendaryRate = legendaryRate.rate;
            legendaryRate.rate = 100;
        }
        else if (legendaryWishCount == legendaryGuaranty)
        {
            legendaryWishCount = 0;
            legendaryRate.rate = defaultLegendaryRate;
        }
    }

    public ItemScriptableObject findItem(ItemType type, RarityName rarity)
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