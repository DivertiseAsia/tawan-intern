using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UI_Color", menuName = "UI Color")]
public class UI_Color : ScriptableObject
{
    public Color legendary;
    public Color epic;
    public Color rare;
    public Color common;
    
    public static Color GetColor(string myColor)
    {
        Color tmpColor;
        if(ColorUtility.TryParseHtmlString(myColor, out tmpColor)){
            return tmpColor;
        }
        return Color.white;
    }
}
