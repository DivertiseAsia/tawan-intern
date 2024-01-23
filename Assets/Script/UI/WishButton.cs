using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WishButton : MonoBehaviour
{
    

    public int _wishAmount;
    public TextMeshProUGUI _wishText;
    public TextMeshProUGUI _priceText;
    public Image _currencyImage;

    public void Pull()
    {
        GachaManager.Instance.Pull(_wishAmount);
    }
}
