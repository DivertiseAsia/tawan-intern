using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BannerButton : MonoBehaviour
{
    public Banner _banner;
    public static event Action<Banner> OnBannerButtonPressed;

    public void SwitchBanner()
    {
        OnBannerButtonPressed?.Invoke(_banner);
        AudioManager.Instance.PlaySFX("Open");
    }
}


