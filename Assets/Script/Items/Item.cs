using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour
{
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
                _itemPanel.color = UI_Color.GetColor(UI_Color.legendaryColor);
                break;
            case RarityName.Epic:
                _itemPanel.color = UI_Color.GetColor(UI_Color.epicColor);
                break;
            case RarityName.Rare:
                _itemPanel.color = UI_Color.GetColor(UI_Color.rareColor);
                break;
            case RarityName.Common:
                _itemPanel.color = UI_Color.GetColor(UI_Color.commonColor);
                break;
        }
    }
}


