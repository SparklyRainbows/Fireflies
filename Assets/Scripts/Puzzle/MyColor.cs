using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyColor
{
    ColorName colorName;
    Color color;

    public MyColor(ColorName colorName) {
        this.colorName = colorName;

        color = ToColor(colorName);
    }

    public Color GetColor() {
        return color;
    }

    public ColorName GetColorName() {
        return colorName;
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

    /// <summary>
    /// Checks if b can make up a
    /// </summary>
    public static bool IsComposite(ColorName mainColor, ColorName compositeColor) {
        if (mainColor == ColorName.VIOLET &&
            (compositeColor == ColorName.RED || compositeColor == ColorName.BLUE))
            return true;
        if (mainColor == ColorName.GREEN &&
            (compositeColor == ColorName.YELLOW || compositeColor == ColorName.BLUE))
            return true;
        if (mainColor == ColorName.ORANGE &&
            (compositeColor == ColorName.YELLOW || compositeColor == ColorName.RED))
            return true;

        if (mainColor == ColorName.BROWN)
            return true;

        return false;
    }

    public static Color ToColor(ColorName colorName) {
        switch (colorName) {
            case (ColorName.RED):
                return Color.red;
            case (ColorName.BLUE):
                return Color.blue;
            case (ColorName.YELLOW):
                return Color.yellow;
            case (ColorName.VIOLET):
                return new Color(171, 0, 162);
            case (ColorName.ORANGE):
                return new Color(245, 143, 0);
            case (ColorName.GREEN):
                return Color.green;
            case (ColorName.BROWN):
                return new Color(102, 60, 0);
            case (ColorName.NONE):
                return Color.white;
            default:
                Debug.LogError($"Color name not found: {colorName}");
                return Color.white;
        }
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