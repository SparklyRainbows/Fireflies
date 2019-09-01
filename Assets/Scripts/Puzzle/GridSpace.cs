using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    //Light horizontal;
    //Light vertical;
    Light left;
    Light right;
    Light up;
    Light down;

    private void Start() {
        //horizontal = transform.Find("Horizontal").GetComponent<Light>();
        //vertical = transform.Find("Vertical").GetComponent<Light>();

        left = transform.Find("Left").GetComponent<Light>();
        right = transform.Find("Right").GetComponent<Light>();
        up = transform.Find("Up").GetComponent<Light>();
        down = transform.Find("Down").GetComponent<Light>();
    }

    public void ShowLeft(ColorName color) {
        left.Show(color);
    }

    public void ShowRight(ColorName color) {
        right.Show(color);
    }

    public void ShowUp(ColorName color) {
        up.Show(color);
    }

    public void ShowDown(ColorName color) {
        down.Show(color);
    }

    public bool IsLit() {
        return left.IsEnabled() || right.IsEnabled() || up.IsEnabled() || down.IsEnabled();
    }

    public void ShowHorizontal(ColorName color) {
        left.Show(color);
        right.Show(color);
    }

    public void ShowVertical(ColorName color) {
        up.Show(color);
        down.Show(color);
    }

    public void HideHorizontal() {
        left.Hide();
        right.Hide();
    }

    public void HideVertical() {
        up.Hide();
        down.Hide();
    }

    public void HideLeft() {
        left.Hide();
    }

    public void HideRight() {
        right.Hide();
    }

    public void HideUp() {
        up.Hide();
    }

    public void HideDown() {
        down.Hide();
    }

    /// <summary>
    /// Returns a color if horizontal and vertical share the same color
    /// Otherwise returns Color.white
    /// </summary>
    public Color GetSpaceColor() {
        //If all beams are active
        if (left.IsEnabled() && right.IsEnabled() && up.IsEnabled() && down.IsEnabled()) {
            if (left.GetColor() == right.GetColor() && right.GetColor() == up.GetColor() && up.GetColor() == down.GetColor())
                return left.GetColor();
        }

        if (left.IsEnabled())
            return left.GetColor();

        if (up.IsEnabled())
            return up.GetColor();

        return Color.white;
    }
}
