using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCard : MonoBehaviour
{
    [SerializeField] UIColor colorPallete;

    [SerializeField] Image _itemPanel;
    [SerializeField] Image _itemSprite;
    [SerializeField] TextMeshProUGUI _itemTypeText;
    [SerializeField] TextMeshProUGUI _itemNameText;
    [SerializeField] TextMeshProUGUI _itemRarityText;

    public void Setup(ItemScriptableObject itemInfo)
    {
        
        _itemTypeText.text = itemInfo.itemType.ToString();
        _itemSprite.sprite = itemInfo.itemSprite;
        _itemNameText.text = itemInfo.itemName;
        _itemRarityText.text = itemInfo.rarity.ToString();

        SetPanelColor(itemInfo);
    }

    private void SetPanelColor(ItemScriptableObject itemInfo)
    {

        switch (itemInfo.rarity)
        {
            case RarityName.Legendary:
                _itemPanel.color = colorPallete.legendary;
                _itemRarityText.color = colorPallete.legendary;
                break;
            case RarityName.Epic:
                _itemPanel.color = colorPallete.epic;
                _itemRarityText.color = colorPallete.epic;
                break;
            case RarityName.Rare:
                _itemPanel.color = colorPallete.rare;
                _itemRarityText.color = colorPallete.rare;
                break;
            case RarityName.Common:
                _itemPanel.color = colorPallete.common;
                _itemRarityText.color = colorPallete.common;
                break;
        }
    }
}


