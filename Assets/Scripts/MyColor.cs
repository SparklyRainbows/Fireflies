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
}

public enum ColorName {
    RED,
    BLUE,
    YELLOW,
    NONE
}