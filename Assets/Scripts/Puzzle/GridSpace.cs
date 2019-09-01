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
    public ColorName GetSpaceColor() {
        List<MyColor> colors = GetColors();

        if (colors.Count == 0)
            return ColorName.NONE;

        while (colors.Count > 1) {
            MyColor a = colors[0];
            MyColor b = colors[1];
            colors.Remove(a);
            colors.Remove(b);

            MyColor newColor = MyColor.Mix(a.GetColorName(), b.GetColorName());
            colors.Add(newColor);
        }

        return colors[0].GetColorName();
    }

    private List<MyColor> GetColors() {
        List<MyColor> colors = new List<MyColor>();

        if (left.IsEnabled())
            colors.Add(left.GetMyColor());
        if (right.IsEnabled() && !colors.Contains(right.GetMyColor()))
            colors.Add(right.GetMyColor());
        if (up.IsEnabled() && !colors.Contains(up.GetMyColor()))
            colors.Add(up.GetMyColor());
        if (down.IsEnabled() && !colors.Contains(down.GetMyColor()))
            colors.Add(down.GetMyColor());

        return colors;
    }
}
