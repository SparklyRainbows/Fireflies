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
            case (ColorName.NONE):
                color = Color.white;
                return;
            default:
                Debug.LogError($"Color name not found: {colorName}");
                return;
        }
    }

    public static ColorName Mix(List<ColorName> colors) {
        if (colors.Contains(ColorName.RED) && colors.Contains(ColorName.BLUE))
            return ColorName.BROWN;
        return ColorName.BROWN;
    }

    public static ColorName Mix(ColorName a, ColorName b) {
        if ((a == ColorName.RED && b == ColorName.BLUE) || (a == ColorName.BLUE && b == ColorName.RED))
            return ColorName.VIOLET;
        if ((a == ColorName.RED && b == ColorName.YELLOW) || (a == ColorName.YELLOW && b == ColorName.RED))
            return ColorName.ORANGE;
        if ((a == ColorName.BLUE && b == ColorName.YELLOW) || (a == ColorName.YELLOW && b == ColorName.BLUE))
            return ColorName.GREEN;

        return ColorName.BROWN;
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