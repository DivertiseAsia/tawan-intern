using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Weapon", menuName = "Items/Weapon")]
public class WeaponScriptableObject : ItemScriptableObject
{
    [Header("Specific Stats")]
    public int atk;

    private void Reset()
    {
        itemType = ItemType.Weapon;
    }
}
