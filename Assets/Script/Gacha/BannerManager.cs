using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class BannerManager : MonoBehaviour
{
    public PlayerStatus _playerStatus;

    public Image _currencyImage;
    public TextMeshProUGUI _currencyText;

    public TextMeshProUGUI _bannerNameText;

    public Image _HeadImage;
    public Image _BodyImage;
    public Image _WeaponImage;



    public BannerType bannerType;
    public PoolScriptableObject[] pools;

    private void Start()
    {
        UpdateBannerUI();
    }

    public void ChangeBannerToStandard()
    {
        bannerType = BannerType.Standard;
        UpdateBannerUI();
    }
    public void ChangeBannerToLimited()
    {
        bannerType = BannerType.Limited;
        UpdateBannerUI();
    }

    public void Topup(int amount)
    {
        _playerStatus.Topup(bannerType, amount);
        UpdateBannerUI();
    }

    private ItemScriptableObject findItem(PoolScriptableObject pool, BannerType bannerType, ItemType type, RarityName rarity )
    {
        ItemScriptableObject selectedItem = Array.Find(pool.items, item => 
                                                            item.rarity == rarity &&
                                                            item.bannerType == bannerType &&
                                                            item.itemType == type);

        return selectedItem;
    }

    public void UpdateBannerUI()
    {
        _bannerNameText.text = pools[(int)bannerType].bannerName;

        _currencyImage.sprite = pools[(int)bannerType]._currencySprite;
        _currencyText.text = _playerStatus.GetCurrencyAmount(bannerType).ToString();

        _HeadImage.sprite = findItem(pools[(int)bannerType], bannerType, ItemType.Head, RarityName.Legendary).itemSprite;
        _BodyImage.sprite = findItem(pools[(int)bannerType], bannerType, ItemType.Body, RarityName.Legendary).itemSprite;
        _WeaponImage.sprite = findItem(pools[(int)bannerType], bannerType, ItemType.Weapon, RarityName.Legendary).itemSprite;
    }
}

public enum BannerType
{
    Standard,
    Limited
}