using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaManager : MonoBehaviour
{
    public static GachaManager Instance { get; private set; }

    public static event Action<Banner> OnBannerSwitched;

    [Header("Banner")]
    [SerializeField] Banner defaultBanner;
    [SerializeField] Banner currentBanner;

    [Header("Result Panel")]
    [SerializeField] ItemScriptableObject[] itemsResultInfo;

    [Header("Gacha Config")]
    public int gachaPrice = 100;
    [SerializeField] int wishesToGuaranty;
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
        UIManager.Instance.UpdateBannerUI(currentBanner);
    }

    private void SetBanner(Banner banner)
    {
        OnBannerSwitched?.Invoke(banner);

        currentBanner = banner;
        
        currentBanner.SetupPool();
    }

    public void Pull(int amount)
    {
        if (currentBanner._currency.IsCurrencyEnough(gachaPrice * amount))
        {
            currentBanner._currency.Pay(gachaPrice * amount);
            UIManager.Instance.UpdateCurrencyUI();

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

                        currentBanner.UpdateLegendaryCount(gachaRates[j].rarityName);
                        currentBanner.SetLegendaryGuaranty(wishesToGuaranty, gachaRates[0]);

                        break;
                    }
                }
            }

            UIManager.Instance.ShowGachaResult(itemsResultInfo);

        }
        else
        {
            Debug.Log("Currency is not enough");
        }
    }

}
