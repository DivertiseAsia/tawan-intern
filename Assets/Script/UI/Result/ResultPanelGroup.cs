using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResultPanelGroup : MonoBehaviour
{
    [SerializeField] ResultPanel _resultPanelPrefab;
    [SerializeField] OverAllResultPanel _overAllResultPanel;
   
    private ResultPanel[] resultPanels;

    [SerializeField] int currentIndex = -1;

    [SerializeField] GameObject _skipButton;

    private void OnEnable()
    {
        _skipButton.SetActive(true);
        ShowResultPanel();
        ResultPanel.OnResultPanelClick += ShowResultPanel;
    }

    private void OnDisable()
    {
        _skipButton.SetActive(false);
        ResultPanel.OnResultPanelClick -= ShowResultPanel;
    }

    public void SetUp(ItemScriptableObject[] itemsInfo)
    {
        resultPanels = new ResultPanel[itemsInfo.Length];

        for (int i=0; i<itemsInfo.Length; i++)
        {
            ResultPanel resultPanel = Instantiate(_resultPanelPrefab, this.transform);

            resultPanel.SetUp(itemsInfo[i], true);

            resultPanels[i] = resultPanel;
            
            resultPanel.gameObject.SetActive(false);
            
        }

        _overAllResultPanel.SetUp(itemsInfo);
    }

    public void ShowResultPanel()
    {
        currentIndex++;

        if(currentIndex < resultPanels.Length)
        {
            resultPanels[currentIndex].gameObject.SetActive(true);
        }
        else
        {
            Skip();
        }
    }

    public void Skip()
    {
        currentIndex = -1;
        foreach (Transform item in transform)
        {
            Destroy(item.gameObject);
        }

        if (resultPanels.Length > 1)
        {
            
            //UIManager.Instance.ShowOverAllResult();
            _overAllResultPanel.gameObject.SetActive(true);
        }
        gameObject.SetActive(false);
    }
}
