using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System.Linq;
using System;

public class PreResultPanel : MonoBehaviour
{
    [SerializeField] Image _chest;
    [SerializeField] CanvasGroup _cardBack;
    [SerializeField] ResultPanelGroup _resultPanelGroup;


    [Header("Drop")]
    [SerializeField] float dropDuration;
    [SerializeField] float startPosY;
    [SerializeField] float endPosY;

    Rarity rarestRarity;
    [Header("Shake & Color")]
    [SerializeField] ColorPalette _colorPalette;
    [SerializeField] float shakeDuration;
    [SerializeField] float shakeStr;
    [SerializeField] int shakeVi;
    [SerializeField] float shakeRand;

    [Header("Scale")]
    [SerializeField] float fadeDuration;
    [SerializeField] float scaleDuration;
    [SerializeField] Vector3 endScale;

    [Header("Fly Out")]
    [SerializeField] float flyDuration;

    Sequence seq;

    private void OnEnable()
    {
        seq = DOTween.Sequence();
        startPosY = _chest.rectTransform.anchoredPosition.y;
        ShowChest();
    }

    private void OnDisable()
    {       
        //ShowChest(0.1f, 0.1f, startPosY, Color.white);
        ResetChest();
    }

    public void SetUp(ItemScriptableObject[] itemsInfo)
    {
        rarestRarity = itemsInfo.Min(x => x.rarity);
        _cardBack.GetComponent<ItemCardBack>().SetPanelColor(rarestRarity);
        _resultPanelGroup.SetUp(itemsInfo);
    }

    private void ShowChest()
    {
        
        seq.Append(_chest.rectTransform.DOAnchorPosY(endPosY, dropDuration)
            .SetEase(Ease.OutBounce)
            .OnStart(() => AudioManager.Instance.PlaySFX("Open")));

        
        seq.Append(_chest.DOColor(_colorPalette.GetRarityColor(rarestRarity), shakeDuration)
            .SetEase(Ease.InBack))
            .Join(_chest.rectTransform.DOShakeAnchorPos(shakeDuration, shakeStr, shakeVi, shakeRand, false, true)
            .OnStart(() => AudioManager.Instance.PlaySFX("Close")));

        
        seq.Append(_chest.rectTransform.DOScale(endScale, scaleDuration)
            .SetEase(Ease.InBounce)
            .OnStart(() => AudioManager.Instance.PlaySFX("3")));

        
        seq.Append(_chest.DOFade(0f, fadeDuration))
            .Join(_cardBack.DOFade(1f, fadeDuration)
            .OnStart(() => AudioManager.Instance.PlaySFX("4")));

        
        seq.Append(_cardBack.transform.DOLocalMoveY(startPosY, flyDuration)
            .SetEase(Ease.InBack)
            .OnStart(() => AudioManager.Instance.PlaySFX("Fly")))            
            .OnComplete(() =>
            {
                _resultPanelGroup.gameObject.SetActive(true);
                gameObject.SetActive(false);
            });
    }

    private void ResetChest()
    {
        _chest.rectTransform.DOAnchorPosY(startPosY, 0.1f);

        _chest.DOColor(Color.white, 0.1f);

        _chest.rectTransform.DOScale(Vector3.one , 0.1f);

        _chest.DOFade(1f, 0.1f);

        _cardBack.DOFade(0f, 0.1f);

        _cardBack.transform.DOLocalMoveY(0, 0.1f);
    }

    public void Skip()
    {
        seq.Kill();

        _resultPanelGroup.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    

}
