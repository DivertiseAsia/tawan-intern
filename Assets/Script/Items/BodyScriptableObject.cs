using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Body", menuName = "Items/Body")]
public class BodyScriptableObject : ItemScriptableObject
{
    [Header("Specific Stats")]
    public int str;

    private void Reset()
    {
        itemType = ItemType.Body;
    }
}
