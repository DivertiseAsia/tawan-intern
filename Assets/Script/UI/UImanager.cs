using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [Header("--PlayerStatus--")]
    [SerializeField] PlayerStatus _playerStatus;

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
    Sprite currentCurrencySprite;

    [Header("--Result Panel--")]
    [SerializeField] Item itemPrefab;
    [SerializeField] GameObject _resultPanel;
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
        BannerManager.OnBannerSwitched += UpdateBannerUI;
    }

    private void OnDisable()
    {
        BannerManager.OnBannerSwitched -= UpdateBannerUI;
    }

    public void Topup(int amount)
    {
        _playerStatus.Topup(amount);
        UpdateCurrencyUI();
    }

    public void ShowGachaResult(ItemScriptableObject[] itemsInfo)
    {
        foreach (ItemScriptableObject itemInfo in itemsInfo)
        {
            Item item = Instantiate(itemPrefab, _contentsTransform);
            item.Setup(itemInfo);
        }


        _resultPanel.SetActive(true);
        _itemsScrollRect.horizontalNormalizedPosition = 0;
    }

    public void CloseResultPanel()
    {
        _resultPanel.SetActive(false);
        foreach (Transform item in _contentsTransform)
        {
            Destroy(item.gameObject);
        }
    }

    public void UpdateBannerUI(BannerManager bannerManager)
    {
        _bannerNameText.text = bannerManager.currentBanner.bannerName;


        currentCurrencySprite = bannerManager.currentBanner._currencySprite;
        UpdateCurrencyUI();

        UpdateWishButton();

        UpdateBannerButtonPos(bannerManager.currentBanner);

        _HeadImage.sprite = bannerManager.findItem(ItemType.Head, RarityName.Legendary).itemSprite;
        _BodyImage.sprite = bannerManager.findItem(ItemType.Body, RarityName.Legendary).itemSprite;
        _WeaponImage.sprite = bannerManager.findItem(ItemType.Weapon, RarityName.Legendary).itemSprite;

    }

    public void UpdateCurrencyUI()
    {
        _currencyText.text = _playerStatus.currentCurrency.amount.ToString();
        _currencyImage.sprite = currentCurrencySprite;
    }

    private void UpdateWishButton()
    {
        int gachaPrice = GachaManager.Instance.gachaPrice;
        foreach (WishButton btn in _wishButtons)
        {
            btn._wishText.text = $"Wish x{btn._wishAmount}";
            btn._priceText.text = $"x {gachaPrice* btn._wishAmount}";
            btn._currencyImage.sprite = currentCurrencySprite;
        }
    }
    public void UpdateBannerButtonPos(BannerScriptableObject banner)
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
                btn.transform.localPosition = new Vector3(selectedPosX+defaultPosX, btn.transform.localPosition.y, 0);
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
