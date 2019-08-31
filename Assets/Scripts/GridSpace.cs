using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSpace : MonoBehaviour
{
    SpriteRenderer horizontal;
    SpriteRenderer vertical;

    private void Start() {
        horizontal = transform.Find("Horizontal").GetComponent<SpriteRenderer>();
        vertical = transform.Find("Vertical").GetComponent<SpriteRenderer>();
    }

    public bool IsLit() {
        return horizontal.enabled || vertical.enabled;
    }

    public void ShowHorizontal(Color color) {
        horizontal.enabled = true;
        horizontal.color = color;
    }

    public void ShowVertical(Color color) {
        vertical.enabled = true;
        vertical.color = color;
    }

    public void HideHorizontal() {
        horizontal.enabled = false;
    }

    public void HideVertical() {
        vertical.enabled = false;
    }
}
