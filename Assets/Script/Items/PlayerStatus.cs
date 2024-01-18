using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, IDataPersistence
{
    public Star stars;
    public Diamond diamonds;

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

    public int GetCurrencyAmount(BannerType bannerType)
    {
        if (bannerType == BannerType.Standard)
            return stars.amount;

        if (bannerType == BannerType.Limited)
            return diamonds.amount;
        
        else return 0;        
    }

    public void Pay(BannerType bannerType, int price)
    {
        if (bannerType == BannerType.Standard)
            stars.DecreaseAmount(price);
        else if (bannerType == BannerType.Limited)
            diamonds.DecreaseAmount(price);
    }

    public void Topup(BannerType bannerType, int price)
    {
        if (bannerType == BannerType.Standard)
            stars.IncreaseAmount(price);
        else if (bannerType == BannerType.Limited)
            diamonds.IncreaseAmount(price);
    }

    public bool isCurrencyEnough(BannerType bannerType, int price)
    {
        if(bannerType == BannerType.Standard)
            return stars.amount >= price ? true : false;
        else if(bannerType == BannerType.Limited)
            return diamonds.amount >= price ? true : false;
        else return false;
    }
}
