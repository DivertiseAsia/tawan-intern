using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDataPersistence
{
    public Star stars;
    public Diamond diamonds;
    public Currencies currentCurrency;

    private void OnEnable()
    {
        BannerManager.OnBannerSwitched += ChangeCurrency;
    }

    private void OnDisable()
    {
        BannerManager.OnBannerSwitched -= ChangeCurrency;
    }
    
    private void ChangeCurrency(BannerManager bannerManager)
    {
        switch (bannerManager.bannerType)
        {
            case BannerType.Standard:
                currentCurrency = stars;
                Debug.Log("currency = stars");
                break;
            case BannerType.Limited: 
                currentCurrency = diamonds;
                Debug.Log("currency = diamonds");
                break;
            default: 
                break;
        }
    }

    public void LoadData(GameData data)
    {
        this.stars.amount = data.starAmount;
        this.diamonds.amount = data.diamondAmount;
    }

    public void SaveData(GameData data)
    {
        data.starAmount = this.stars.amount;
        data.diamondAmount = this.diamonds.amount;
    }

    public void Pay(int price)
    {
        currentCurrency.DecreaseAmount(price);
    }

    public void Topup(int price)
    {
        currentCurrency.IncreaseAmount(price);
    }

    public bool isCurrencyEnough(int price)
    {
        return currentCurrency.amount >= price ? true : false;
    }
}
