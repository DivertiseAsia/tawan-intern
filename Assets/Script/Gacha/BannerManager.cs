using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BannerManager : MonoBehaviour
{
    #region

    public static event Action<BannerManager> OnBannerSwitched;

    #endregion

    public BannerType bannerType;
    public BannerScriptableObject defaultBanner;
    public BannerScriptableObject currentBanner;

    private void Start()
    {
        SwitchBanner(defaultBanner);
    }

    public void SwitchBanner(BannerScriptableObject banner)
    {
        currentBanner = banner;
        this.bannerType = banner.bannerType;

        AudioManager.Instance.PlaySFX("Open");

        OnBannerSwitched?.Invoke(this);
    }

    public ItemScriptableObject findItem(ItemType type, RarityName rarity)
    {
        ItemScriptableObject selectedItem = Array.Find(currentBanner.items, item =>
                                                            item.rarity == rarity &&
                                                            item.bannerType == bannerType &&
                                                            item.itemType == type);

        return selectedItem;
    }

    public ItemScriptableObject findItem(BannerScriptableObject banner, BannerType bannerType, ItemType type, RarityName rarity )
    {
        ItemScriptableObject selectedItem = Array.Find(banner.items, item => 
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