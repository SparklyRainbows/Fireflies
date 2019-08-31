using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    Light horizontal;
    Light vertical;

    private void Start() {
        horizontal = transform.Find("Horizontal").GetComponent<Light>();
        vertical = transform.Find("Vertical").GetComponent<Light>();
    }

    public bool IsLit() {
        return horizontal.IsEnabled() || vertical.IsEnabled();
    }

    public void ShowHorizontal(ColorName color) {
        horizontal.Show(color);
    }

    public void ShowVertical(ColorName color) {
        vertical.Show(color);
    }

    public void HideHorizontal() {
        horizontal.Hide();
    }

    public void HideVertical() {
        vertical.Hide();
    }

    /// <summary>
    /// Returns a color if horizontal and vertical share the same color
    /// Otherwise returns Color.white
    /// </summary>
    public Color GetSpaceColor() {
        //If both beams are active
        if (horizontal.IsEnabled() && vertical.IsEnabled()) {
            if (horizontal.GetColor() == vertical.GetColor())
                return horizontal.GetColor();

            return Color.white;
        }

        if (horizontal.IsEnabled())
            return horizontal.GetColor();

        if (vertical.IsEnabled())
            return vertical.GetColor();

        return Color.white;
    }
}
