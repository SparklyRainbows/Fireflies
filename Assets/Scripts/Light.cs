using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    SpriteRenderer sprite;
    MyColor myColor;

    private void Start() {
        sprite = GetComponent<SpriteRenderer>();
    }

    public bool IsEnabled() {
        return sprite.enabled;
    }

    public void Show(ColorName color) {
        sprite.enabled = true;

        myColor = new MyColor(color);
        sprite.color = GetColor();
    }

    public void Hide() {
        sprite.enabled = false;
    }

    public Color GetColor() {
        return myColor.GetColor();
    }
}
