using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCard : MonoBehaviour
{
    [SerializeField] ColorPalette colorPallete;

    [SerializeField] Image _itemCard;
    [SerializeField] GameObject cardBack;
    [SerializeField] GameObject cardFront;
    [SerializeField] Image _itemSprite;
    [SerializeField] TextMeshProUGUI _itemTypeText;
    [SerializeField] TextMeshProUGUI _itemNameText;
    [SerializeField] TextMeshProUGUI _itemRarityText;

    public void Setup(ItemScriptableObject itemInfo, bool showCardBack)
    {
        
        _itemTypeText.text = itemInfo.itemType.ToString();
        _itemSprite.sprite = itemInfo.itemSprite;
        _itemNameText.text = itemInfo.itemName;
        _itemRarityText.text = itemInfo.rarity.ToString();

        SetPanelColor(itemInfo);
  
        cardBack.GetComponent<ItemCardBack>().SetPanelColor(itemInfo.rarity);
        cardBack.gameObject.SetActive(showCardBack);       
    }

    private void SetPanelColor(ItemScriptableObject itemInfo)
    {
        Color rarityColor = colorPallete.GetRarityColor(itemInfo.rarity);
        _itemCard.color = rarityColor;
        _itemRarityText.color = rarityColor;
    }
}


