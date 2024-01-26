using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGachaManager : MonoBehaviour
{
    public static NewGachaManager Instance { get; private set; }

    public static event Action<Banner> OnBannerSwitched;

    [Header("Banner")]
    [SerializeField] Banner currentBanner;
    [SerializeField] Banner defaultBanner;

    [Header("Managers")]
    [SerializeField] private PlayerStatus _playerStatus;

    [Header("Result Panel")]
    [SerializeField] ItemScriptableObject[] itemsResultInfo;

    [Header("Gacha Config")]
    public int gachaPrice = 100;
    public int legendaryGuaranty;
    public GachaRate[] gachaRates = new GachaRate[4];
    

    private void OnEnable()
    {
        BannerButton.OnBannerButtonPressed += SetBanner;
    }

    private void OnDisable()
    {
        BannerButton.OnBannerButtonPressed -= SetBanner;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene");
        }
        Instance = this;
    }

    private void Start()
    {
        SetBanner(defaultBanner);
        NewUIManager.Instance.UpdateBannerUI(currentBanner);
    }

    private void SetBanner(Banner banner)
    {
        OnBannerSwitched?.Invoke(banner);

        currentBanner = banner;
        
        currentBanner.SetupPool();
    }

    public void Pull(int amount)
    {
        if (_playerStatus.isCurrencyEnough(gachaPrice * amount))
        {

            itemsResultInfo = new ItemScriptableObject[amount];

            for (int i = 0; i < itemsResultInfo.Length; i++)
            {
                int random = UnityEngine.Random.Range(1, 101);
                for (int j = 0; j < gachaRates.Length; j++)
                {
                    if (random <= gachaRates[j].rate)
                    {
                        ItemScriptableObject result = currentBanner.GetItems(gachaRates[j].rarityName);

                        itemsResultInfo[i] = result;

                        currentBanner.IncreaseLegendaryCount();
                        currentBanner.SetLegendaryGuaranty(legendaryGuaranty, gachaRates[0]);

                        break;
                    }
                }
            }

            NewUIManager.Instance.ShowGachaResult(itemsResultInfo);

            _playerStatus.Pay(gachaPrice * amount);

            NewUIManager.Instance.UpdateCurrencyUI();

            

        }
        else
        {
            Debug.Log("Currency is not enough");
        }
    }

}
