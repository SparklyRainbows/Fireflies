using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyColor
{
    ColorName colorName;
    Color color;

    public MyColor(ColorName colorName) {
        this.colorName = colorName;

        ConvertToColor();
    }

    public Color GetColor() {
        return color;
    }

    public ColorName GetColorName() {
        return colorName;
    }

    private void ConvertToColor() {
        switch (colorName) {
            case (ColorName.RED):
                color = Color.red;
                return;
            case (ColorName.BLUE):
                color = Color.blue;
                return;
            case (ColorName.YELLOW):
                color = Color.yellow;
                return;
            case (ColorName.VIOLET):
                color = Color.cyan;
                return;
            case (ColorName.ORANGE):
                color = Color.magenta;
                return;
            case (ColorName.GREEN):
                color = Color.green;
                return;
            case (ColorName.BROWN):
                color = Color.gray;
                return;
            case (ColorName.NONE):
                color = Color.white;
                return;
            default:
                Debug.LogError($"Color name not found: {colorName}");
                return;
        }
    }
    
    public static MyColor Mix(ColorName a, ColorName b) {
        List<ColorName> colors = new List<ColorName>() { a, b };

        //Primaries
        if (colors.Contains(ColorName.RED) && colors.Contains(ColorName.BLUE))
            return new MyColor(ColorName.VIOLET);
        if (colors.Contains(ColorName.RED) && colors.Contains(ColorName.YELLOW))
            return new MyColor(ColorName.ORANGE);
        if (colors.Contains(ColorName.YELLOW) && colors.Contains(ColorName.BLUE))
            return new MyColor(ColorName.GREEN);

        //Composites
        if (colors.Contains(ColorName.VIOLET)) {
            if (colors.Contains(ColorName.RED) || colors.Contains(ColorName.BLUE))
                return new MyColor(ColorName.VIOLET);
            else
                return new MyColor(ColorName.BROWN);
        }
        if (colors.Contains(ColorName.ORANGE)) {
            if (colors.Contains(ColorName.RED) || colors.Contains(ColorName.YELLOW))
                return new MyColor(ColorName.ORANGE);
            else
                return new MyColor(ColorName.BROWN);
        }
        if (colors.Contains(ColorName.GREEN)) {
            if (colors.Contains(ColorName.BLUE) || colors.Contains(ColorName.YELLOW))
                return new MyColor(ColorName.GREEN);
            else
                return new MyColor(ColorName.BROWN);
        }

        return new MyColor(ColorName.BROWN);
    }

    public override bool Equals(object obj) {
        MyColor objColor = (MyColor)obj;
        return GetColorName() == objColor.GetColorName();
    }
}

public enum ColorName {
    RED,
    BLUE,
    YELLOW,
    VIOLET,
    ORANGE,
    GREEN,
    BROWN,
    NONE
}