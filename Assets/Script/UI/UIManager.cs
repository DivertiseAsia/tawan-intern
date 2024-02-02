using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("--Gacha Wish Button--")]
    [SerializeField] WishButton[] _wishButtons;

    [Header("--Gacha Banner Button--")]
    [SerializeField] BannerButton[] _bannerButtons;
    [SerializeField] int defaultPosX;
    [SerializeField] int selectedPosX;
    [SerializeField] Color defaultColor;
    [SerializeField] Color selectedColor;

    [Header("--Currency--")]
    [SerializeField] Image _currencyImage;
    [SerializeField] TextMeshProUGUI _currencyText;
    Currency currentCurrency;

    [Header("--Result Panel--")]
    [SerializeField] GameObject _overAllResultPanel;
    [SerializeField] PreResultPanel _preResultPanel;
    [SerializeField] ItemCard itemPrefab;
    [SerializeField] ScrollRect _itemsScrollRect;
    [SerializeField] RectTransform _contentsTransform;

    [Header("--BannerName--")]
    [SerializeField] TextMeshProUGUI _bannerNameText;

    [Header("--Legend Item to show--")]
    [SerializeField] Image _HeadImage;
    [SerializeField] Image _BodyImage;
    [SerializeField] Image _WeaponImage;

    private void OnEnable()
    {        
        GachaManager.OnBannerSwitched += UpdateBannerUI;       
    }

    private void OnDisable()
    {        
        GachaManager.OnBannerSwitched -= UpdateBannerUI;       
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Found more than one Data Persistence Manager in the scene");
        }
        Instance = this;
    }

    public void Topup(int amount)
    {
        AudioManager.Instance.PlaySFX("Open");
        currentCurrency.Topup(amount);
        UpdateCurrencyUI();
    }

    public void ShowGachaResult(ItemScriptableObject[] itemsInfo)
    {
        foreach (ItemScriptableObject itemInfo in itemsInfo)
        {
            ItemCard item = Instantiate(itemPrefab, _contentsTransform);
            item.Setup(itemInfo, true);
        }

        _overAllResultPanel.SetActive(true);
        _itemsScrollRect.horizontalNormalizedPosition = 0;
    }

    public void ShowGachaPreResult(ItemScriptableObject[] itemsInfo)
    {
        foreach (Transform item in _contentsTransform)
        {
            Destroy(item.gameObject);
        }
        /*
        foreach (ItemScriptableObject itemInfo in itemsInfo)
        {
            ItemCard item = Instantiate(itemPrefab, _contentsTransform);
            item.Setup(itemInfo, false);
        }
        */
        _preResultPanel.SetUp(itemsInfo);
        _preResultPanel.gameObject.SetActive(true);        
    }

    public void ShowOverAllResult()
    {
        //_overAllResultPanel.SetActive(true);
        _itemsScrollRect.horizontalNormalizedPosition = 0;
    }

    public void CloseResultPanel()
    {
        _overAllResultPanel.SetActive(false);
        
    }

    public void ShowPanel(GameObject panel)
    {
        AudioManager.Instance.PlaySFX("Open");
        panel.SetActive(true);
    }

    public void ClosePanel(GameObject panel)
    {
        AudioManager.Instance.PlaySFX("Close");
        panel.SetActive(false);
    }

    public void UpdateBannerUI(Banner banner)
    {
        _bannerNameText.text = banner.bannerName;

        currentCurrency = banner._currency;
        UpdateCurrencyUI();

        UpdateWishButton();

        UpdateBannerButtonPos(banner);

        _HeadImage.sprite = banner.findItem(ItemType.Head, Rarity.Legendary).itemSprite;
        _BodyImage.sprite = banner.findItem(ItemType.Body, Rarity.Legendary).itemSprite;
        _WeaponImage.sprite = banner.findItem(ItemType.Weapon, Rarity.Legendary).itemSprite;

    }

    public void UpdateCurrencyUI()
    {
        _currencyText.text = currentCurrency.amount.ToString();
        _currencyImage.sprite = currentCurrency.sprite;
    }

    private void UpdateWishButton()
    {
        int gachaPrice = GachaManager.Instance.gachaPrice;
        foreach (WishButton btn in _wishButtons)
        {
            btn._wishText.text = $"Wish x{btn._wishAmount}";
            btn._priceText.text = $"x {gachaPrice * btn._wishAmount}";
            btn._currencyImage.sprite = currentCurrency.sprite;
        }
    }

    public void UpdateBannerButtonPos(Banner banner)
    {
        foreach (BannerButton btn in _bannerButtons)
        {
            if (btn._banner == banner)
            {
                btn.transform.localPosition = new Vector3(selectedPosX + defaultPosX, btn.transform.localPosition.y, 0);
                btn.GetComponent<Button>().image.color = selectedColor;
            }
            else
            {
                btn.transform.localPosition = new Vector3(defaultPosX, btn.transform.localPosition.y, 0);
                btn.GetComponent<Button>().image.color = defaultColor;
            }
        }
    }

    public void UpdateButtonPos(BannerButton currentButton)
    {
        foreach (BannerButton btn in _bannerButtons)
        {
            if (btn == currentButton)
            {
                btn.transform.localPosition = new Vector3(selectedPosX + defaultPosX, btn.transform.localPosition.y, 0);
                btn.GetComponent<Button>().image.color = selectedColor;
            }
            else
            {
                btn.transform.localPosition = new Vector3(defaultPosX, btn.transform.localPosition.y, 0);
                btn.GetComponent<Button>().image.color = defaultColor;
            }
        }
    }

}
