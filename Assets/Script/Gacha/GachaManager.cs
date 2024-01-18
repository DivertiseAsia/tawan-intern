using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    public GameObject _result_1_Panel;
    public GameObject _result_10_Panel;

    public BannerManager _bannerManager;
    
    public PlayerStatus _playerStatus;

    public int gachaPrice = 100;

    public Item itemResult;
    public Item[] itemsResult = new Item[10];


    public GachaRate[] gachaRates = new GachaRate[4];

    public void PullOne()
    {
        if(_playerStatus.isCurrencyEnough(_bannerManager.bannerType, gachaPrice))
        {
            Debug.Log("Start PullOne");
            int random = Random.Range(1, 101);
            for (int i = 0; i < gachaRates.Length; i++)
            {
                if (random <= gachaRates[i].rate)
                {
                    Debug.Log("Randomed Rate " + random);
                    Debug.Log("Is in Rate of" + gachaRates[i].rate);
                    Debug.Log("Rarity Is " + gachaRates[i].rarityName);

                    ItemScriptableObject result = gachaResult(gachaRates[i].rarityName);
                    itemResult.Setup(result);

                    break;


                    //Show Gacha
                }
            }

            _result_1_Panel.SetActive(true);

            _playerStatus.Pay(_bannerManager.bannerType, gachaPrice);
            
            _bannerManager.UpdateBannerUI();

            Debug.Log("End PullOne");
        }
        else
        {
            Debug.Log("Currency is not enough");
        }
    }



    public void PullTen()
    {
        if (_playerStatus.isCurrencyEnough(_bannerManager.bannerType, gachaPrice*10))
        {
            Debug.Log("Start PullTen");

            foreach (Item item in itemsResult)
            {
                int random = Random.Range(1, 101);
                for (int j = 0; j < gachaRates.Length; j++)
                {
                    if (random <= gachaRates[j].rate)
                    {
                        Debug.Log("Randomed Rate " + random);
                        Debug.Log("Is in Rate of" + gachaRates[j].rate);
                        Debug.Log("Rarity Is " + gachaRates[j].rarityName);

                        ItemScriptableObject result = gachaResult(gachaRates[j].rarityName);
                        item.Setup(result);

                        break;
                    }
                }
            }

            _result_10_Panel.SetActive(true);

            _playerStatus.Pay(_bannerManager.bannerType, gachaPrice*10);
            
            _bannerManager.UpdateBannerUI();

            Debug.Log("End PullTen");
        }
        else
        {
            Debug.Log("Currency is not enough");
        }

        
    }

    public ItemScriptableObject gachaResult(RarityName rarity)
    {
        ItemScriptableObject[] selectedPool = _bannerManager.pools[(int)_bannerManager.bannerType].GetItemsList(rarity);
        
        int random = Random.Range(0, selectedPool.Length);

        return selectedPool[random];
    }
    
}
