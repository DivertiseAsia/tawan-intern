using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_ResultPanel : MonoBehaviour
{
    public GameObject _resultPanel;
    public void ClosePanel()
    {
        _resultPanel.SetActive(false);
    }
}
