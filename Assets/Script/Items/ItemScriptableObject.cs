using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemScriptableObject : ScriptableObject
{
    [Header("Item Info")]
    public string itemName;
    public Sprite itemSprite;

    [Header("Types")]
    public BannerType bannerType;
    public Rarity rarity;
    public ItemType itemType;
}

public enum Rarity
{
    Legendary,
    Epic,
    Rare,
    Common
}

public enum ItemType
{
    Weapon,
    Head,
    Body
}


