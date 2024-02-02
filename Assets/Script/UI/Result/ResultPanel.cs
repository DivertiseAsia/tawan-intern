using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

[System.Serializable]
public class ResultPanel : MonoBehaviour
{
    public static Action OnResultPanelClick;

    [SerializeField] ItemCard _card;
    [SerializeField] CanvasGroup _cardBack;

    [Header("Fly In")]
    [SerializeField] float flyInDuration;
    [SerializeField] float startPosY;
    [SerializeField] float endPosY;

    [Header("Fly Out")]
    [SerializeField] float flyOutDuration;
    [SerializeField] float endPosX;

    [Header("Scale")]
    [SerializeField] float scaleDuration;
    [SerializeField] Vector3 endScale;

    Sequence seq;


    private void OnEnable()
    {
        seq = DOTween.Sequence();
        startPosY = _card.transform.localPosition.y;
        ShowCard();
    }

    public void SetUp(ItemScriptableObject itemInfo, bool showCardBack)
    {
        _card.Setup(itemInfo, showCardBack);
    }

    private void ShowCard()
    {   
        seq.Append(_card.transform.DOLocalMoveY(endPosY, flyInDuration).SetEase(Ease.OutBack));

        seq.Append(_cardBack.transform.DOLocalMoveX(endPosX, flyOutDuration).SetEase(Ease.InExpo))
            .Join(_cardBack.DOFade(0, flyOutDuration));

        seq.Append(_card.transform.DOScale(endScale, scaleDuration).SetEase(Ease.OutBounce));        
    }

    private void ResetCard()
    {
        Sequence seq = DOTween.Sequence();

        seq.Append(_card.transform.DOLocalMoveY(startPosY, 0.1f));

        seq.Append(_cardBack.transform.DOLocalMoveX(0, 0.1f))
            .Join(_cardBack.DOFade(1, 0.1f));

        seq.Append(_card.transform.DOScale(Vector3.one, 0.1f));

    }

    public void Next()
    {
        seq.Kill();
        OnResultPanelClick?.Invoke();
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        seq.Kill();
    }

}
