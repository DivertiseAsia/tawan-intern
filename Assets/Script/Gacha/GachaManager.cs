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
    [SerializeField] public Item[] itemsResult = new Item[10];
    [SerializeField] ItemScriptableObject[] itemsResultInfo;

    [Header("Gacha Config")]
    public int gachaPrice = 100;
    public GachaRate[] gachaRates = new GachaRate[4];

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
