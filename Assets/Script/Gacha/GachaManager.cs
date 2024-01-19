using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    [Header("Managers")]
    [SerializeField] private BannerManager _bannerManager;
    [SerializeField] private UImanager _uiManager;    
    [SerializeField] private PlayerStatus _playerStatus;

    [Header("Result Panel")]
    [SerializeField] private GameObject _result_1_Panel;
    [SerializeField] private GameObject _result_10_Panel;
    [SerializeField] private Item itemResult;
    [SerializeField] public Item[] itemsResult = new Item[10];
    [SerializeField] ItemScriptableObject[] itemsResultInfo;

    [Header("Gacha Config")]
    public int gachaPrice = 100;
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

                    ItemScriptableObject result = GachaResult(gachaRates[i].rarityName);
                    itemResult.Setup(result);

                    break;


                    //Show Gacha
                }
            }

            _result_1_Panel.SetActive(true);

            _playerStatus.Pay(_bannerManager.bannerType, gachaPrice);
            
            _uiManager.UpdateBannerUI();

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

                        ItemScriptableObject result = GachaResult(gachaRates[j].rarityName);
                        item.Setup(result);

                        break;
                    }
                }
            }

            _result_10_Panel.SetActive(true);

            _playerStatus.Pay(_bannerManager.bannerType, gachaPrice*10);
            
            _uiManager.UpdateBannerUI();

            Debug.Log("End PullTen");
        }
        else
        {
            Debug.Log("Currency is not enough");
        }

        
    }

    public void Pull(int amount)
    {
        if (_playerStatus.isCurrencyEnough(_bannerManager.bannerType, gachaPrice * amount))
        {
            Debug.Log("Start Pull " + amount);

            itemsResultInfo = new ItemScriptableObject[amount];

            for (int i = 0; i < itemsResultInfo.Length; i++)
            {
                int random = Random.Range(1, 101);
                for (int j = 0; j < gachaRates.Length; j++)
                {
                    if (random <= gachaRates[j].rate)
                    {
                        Debug.Log("Randomed Rate " + random);
                        Debug.Log("Is in Rate of" + gachaRates[j].rate);
                        Debug.Log("Rarity Is " + gachaRates[j].rarityName);

                        ItemScriptableObject result = GachaResult(gachaRates[j].rarityName);

                        itemsResultInfo[i] = result;

                        break;
                    }
                }
            }

            _uiManager.ShowGachaResult(itemsResultInfo);

            _playerStatus.Pay(_bannerManager.bannerType, gachaPrice * amount);

            _uiManager.UpdateBannerUI();

            Debug.Log("End Pull "+ amount);

        }
        else
        {
            Debug.Log("Currency is not enough");
        }
    }

    public ItemScriptableObject GachaResult(RarityName rarity)
    {
        ItemScriptableObject[] selectedPool = _bannerManager.pools[(int)_bannerManager.bannerType].GetItemsList(rarity);
        
        int random = Random.Range(0, selectedPool.Length);

        return selectedPool[random];
    }
    
}
