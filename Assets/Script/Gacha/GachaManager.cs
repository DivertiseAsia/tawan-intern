using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    public static GachaManager Instance { get; private set; }

    [Header("Managers")]
    [SerializeField] private BannerManager _bannerManager;
    [SerializeField] private UImanager _uiManager;    
    [SerializeField] private PlayerStatus _playerStatus;

    [Header("Result Panel")]
    [SerializeField] ItemScriptableObject[] itemsResultInfo;

    [Header("Gacha Config")]
    public int gachaPrice = 100;
    public GachaRate[] gachaRates = new GachaRate[4];

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene");
        }
        Instance = this;
    }

    public void Pull(int amount)
    {
        if (_playerStatus.isCurrencyEnough(gachaPrice * amount))
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

            _playerStatus.Pay(gachaPrice * amount);

            _uiManager.UpdateCurrencyUI();

            Debug.Log("End Pull "+ amount);

        }
        else
        {
            Debug.Log("Currency is not enough");
        }
    }

    public ItemScriptableObject GachaResult(RarityName rarity)
    {
        ItemScriptableObject[] selectedPool = _bannerManager.currentBanner.GetItemsList(rarity);

        int random = Random.Range(0, selectedPool.Length);

        return selectedPool[random];
    }
    
}
