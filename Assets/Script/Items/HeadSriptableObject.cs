using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Head", menuName = "Items/Head")]
public class HeadSriptableObject : ItemScriptableObject
{
    [Header("Specific Stats")]
    public int hp;

    private void Reset()
    {
        itemType = ItemType.Head;
    }
}
