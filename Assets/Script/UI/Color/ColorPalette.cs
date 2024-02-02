using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "UI_Color", menuName = "UI Color")]
public class ColorPalette : ScriptableObject
{

    [SerializeField] RarityColor[] rarityColor;
    public Color GetRarityColor(Rarity rarity)
    {
        RarityColor selectedColor = Array.Find(rarityColor, rarityColor => rarityColor.rarity == rarity);
        return selectedColor.color;
    }
}
