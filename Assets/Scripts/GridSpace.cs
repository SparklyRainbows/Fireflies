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

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Firefly") && !collision.gameObject.GetComponent<Firefly>().IsDragging()) {
            //Grid.instance.UpdateFireflyLocation(gameObject.name, collision.gameObject);
        }
    }
}
