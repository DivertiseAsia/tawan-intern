using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class OverAllResultPanel : MonoBehaviour
{
    [SerializeField] ItemCard _itemCardPrefab;
    [SerializeField] ScrollRect _itemsScrollRect;
    [SerializeField] RectTransform _contentsTransform;

    [SerializeField] float startPosY;
    [SerializeField] float[] endPosY;
    [SerializeField] float floatDurarion;
    [SerializeField] float durationOffSet;

    private ItemCard[] items;

    
    private void OnEnable()
    {
        SetPosition();
        ShowOverAllResultPanel();
        //_itemsScrollRect.horizontalNormalizedPosition = 0;

    }

    private void OnDisable()
    {
        
    }

    public void SetUp(ItemScriptableObject[] itemsInfo)
    {        
        endPosY = new float[itemsInfo.Length];
        items = new ItemCard[itemsInfo.Length];


        for (int i=0; i<itemsInfo.Length; i++)
        {
            items[i] = Instantiate(_itemCardPrefab, _contentsTransform);
            endPosY[i] = items[i].transform.localPosition.y;

            items[i].Setup(itemsInfo[i], false);
        }

        foreach (ItemCard item in items)
        {
            item.transform.localPosition = new Vector2(item.transform.localPosition.x, startPosY);
        }
        //_contentsTransform.GetComponent<ContentSizeFitter>().enabled = false;
        //_contentsTransform.GetComponent<HorizontalLayoutGroup>().enabled = false;


    }

    private void SetPosition()
    {
        foreach (ItemCard item in items)
        {
            item.transform.localPosition = new Vector2(item.transform.localPosition.x, startPosY);
        }

        _contentsTransform.GetComponent<ContentSizeFitter>().enabled = false;
        _contentsTransform.GetComponent<HorizontalLayoutGroup>().enabled = false;
    }

    public void ShowOverAllResultPanel()
    {
        float dur = durationOffSet;
        int index = 0;
        foreach (Transform transform in _contentsTransform)
        {
            
            transform.DOLocalMoveY(endPosY[index], floatDurarion + dur).SetEase(Ease.OutBack);
            
            dur += durationOffSet;
            index++;
        }
        _contentsTransform.GetComponent<ContentSizeFitter>().enabled = true;
        _contentsTransform.GetComponent<HorizontalLayoutGroup>().enabled = true;

    }

    
}
