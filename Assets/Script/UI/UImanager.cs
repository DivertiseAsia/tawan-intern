using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [Header("Banner Manager & PlayerStatus")]
    
    [SerializeField] private BannerManager bannerManager;
    [SerializeField] private PlayerStatus _playerStatus;

    [Header("UI Elements")]

    public Image _currencyImage;
    public TextMeshProUGUI _currencyText;

    public TextMeshProUGUI _bannerNameText;

    [Header("Legend Item to show")]
    public Image _HeadImage;
    public Image _BodyImage;
    public Image _WeaponImage;


    private void Start()
    {
        UpdateBannerUI();
    }

    public void ChangeBannerToStandard()
    {
        bannerManager.bannerType = BannerType.Standard;
        UpdateBannerUI();
    }
    public void ChangeBannerToLimited()
    {
        bannerManager.bannerType = BannerType.Limited;
        UpdateBannerUI();
    }

    public void Topup(int amount)
    {
        _playerStatus.Topup(bannerManager.bannerType, amount);
        UpdateBannerUI();
        Debug.Log("Top up " + amount);
    }

    public void UpdateBannerUI()
    {
        BannerType bannerType = bannerManager.bannerType;
        PoolScriptableObject pool = bannerManager.pools[(int)bannerType];

        _bannerNameText.text = pool.bannerName;
        //_bannerNameText.text = bannerManager.pools[(int)bannerManager.bannerType].bannerName;

        _currencyImage.sprite = pool._currencySprite;
        //_currencyImage.sprite = bannerManager.pools[(int)bannerManager.bannerType]._currencySprite;
        
        _currencyText.text = _playerStatus.GetCurrencyAmount(bannerType).ToString();

        _HeadImage.sprite = bannerManager.findItem(pool, bannerType, ItemType.Head, RarityName.Legendary).itemSprite;
        _BodyImage.sprite = bannerManager.findItem(pool, bannerType, ItemType.Body, RarityName.Legendary).itemSprite;
        _WeaponImage.sprite = bannerManager.findItem(pool, bannerType, ItemType.Weapon, RarityName.Legendary).itemSprite;
    }
}
