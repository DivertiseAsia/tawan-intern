using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemScriptableObject : ScriptableObject
{
    public BannerType bannerType;
    public ItemType itemType;
    public string itemName;
    public Sprite itemSprite;
    public RarityName rarity;
}

public enum RarityName
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


