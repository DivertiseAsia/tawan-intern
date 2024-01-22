using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [Header("Banner Manager & PlayerStatus")]
    
    [SerializeField] BannerManager bannerManager;
    [SerializeField] PlayerStatus _playerStatus;

    [Header("Gacha Panel")]

    [SerializeField] Button _standardButton;
    [SerializeField] Button _limitedButton;
    [SerializeField] int defaultPosX;
    [SerializeField] int selectedPosX;
    [SerializeField] Color defaultColor;
    [SerializeField] Color selectedColor;

    [SerializeField] Image _currencyImage;
    [SerializeField] TextMeshProUGUI _currencyText;


    [Header("Result Panel")]
    [SerializeField] Item itemPrefab;
    [SerializeField] GameObject _resultPanel;
    [SerializeField] ScrollRect _itemsScrollRect;
    [SerializeField] RectTransform _contentsTransform;
    
    
    

    [Header("BannerName")]
    
    [SerializeField] TextMeshProUGUI _bannerNameText;
    

    [Header("Legend Item to show")]
    [SerializeField] Image _HeadImage;
    [SerializeField] Image _BodyImage;
    [SerializeField] Image _WeaponImage;

    

    private void Start()
    {
        UpdateBannerUI();
    }

    public void ChangeBannerToStandard()
    {
        bannerManager.bannerType = BannerType.Standard;
        
        UpdateBannerUI();
    }
    public void ChangeBannerToLimited()
    {
        bannerManager.bannerType = BannerType.Limited;
        
        UpdateBannerUI();
    }

    public void Topup(int amount)
    {
        _playerStatus.Topup(bannerManager.bannerType, amount);
        UpdateBannerUI();
        Debug.Log("Top up " + amount);
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

    public void UpdateBannerUI()
    {
        BannerType bannerType = bannerManager.bannerType;
        PoolScriptableObject pool = bannerManager.pools[(int)bannerType];

        _bannerNameText.text = pool.bannerName;
        
        _currencyImage.sprite = pool._currencySprite;        
        
        _currencyText.text = _playerStatus.GetCurrencyAmount(bannerType).ToString();

        _HeadImage.sprite = bannerManager.findItem(pool, bannerType, ItemType.Head, RarityName.Legendary).itemSprite;
        _BodyImage.sprite = bannerManager.findItem(pool, bannerType, ItemType.Body, RarityName.Legendary).itemSprite;
        _WeaponImage.sprite = bannerManager.findItem(pool, bannerType, ItemType.Weapon, RarityName.Legendary).itemSprite;

        ChangeButtonPos();
    }

    private void ChangeButtonPos()
    {
        BannerType bannerType = bannerManager.bannerType;

        if(bannerType== BannerType.Standard)
        {
            _standardButton.transform.localPosition = new Vector3 (selectedPosX, _standardButton.transform.localPosition.y, 0);
            _standardButton.image.color = selectedColor;

            _limitedButton.transform.localPosition = new Vector3(defaultPosX, _limitedButton.transform.localPosition.y, 0);
            _limitedButton.image.color = defaultColor;

        }
        else if(bannerType== BannerType.Limited)
        {
            _standardButton.transform.localPosition = new Vector3(defaultPosX, _standardButton.transform.localPosition.y, 0);
            _standardButton.image.color = defaultColor;

            _limitedButton.transform.localPosition = new Vector3(selectedPosX, _limitedButton.transform.localPosition.y, 0);
            _limitedButton.image.color = selectedColor;
        }
    }

    
}
