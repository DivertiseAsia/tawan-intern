using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class UI_Color
{
    public static string legendaryColor = "#EFDD35";
    public static string epicColor = "#D949E6";
    public static string rareColor = "#6CE878";
    public static string commonColor = "#D9D9D9";
    
    public static Color GetColor(string myColor)
    {
        Color tmpColor;
        if(ColorUtility.TryParseHtmlString(myColor, out tmpColor)){
            return tmpColor;
        }
        return Color.white;
    }
}
