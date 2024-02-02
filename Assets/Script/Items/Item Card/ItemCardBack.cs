using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCardBack : MonoBehaviour
{
    [SerializeField] ColorPalette colorPallete;
    [SerializeField] Image _chestImage;

    public void SetPanelColor(Rarity rarity)
    {
        _chestImage.color = colorPallete.GetRarityColor(rarity);
    }

    public void OnClick()
    {
        gameObject.SetActive(false);
    }
}
