using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    public int location;
    public Color color = Color.red;

    float distance;
    bool dragging;

    Vector3 originalPos;

    Transform transform;

    private void Start() {
        GetComponent<SpriteRenderer>().color = color;

        transform = gameObject.transform;
    }

    private void OnMouseDown() {
        Grid.instance.HideGridColor(location);

        originalPos = transform.position;

        distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        dragging = true;
    }

    private void OnMouseUp() {
        dragging = false;
    }

    private void Update() {
        if (!dragging)
            return;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 rayPoint = ray.GetPoint(distance);
        transform.position = rayPoint;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (dragging)
            return;

        int space = int.Parse(collision.gameObject.name);

        if (location != space && Grid.instance.IsSpaceOccupied(space)) {
            transform.position = originalPos;
        } else {
            Snap(collision.gameObject);
            Grid.instance.UpdateFireflyLocation(collision.gameObject.name, gameObject);
        }
    }

    private void Snap(GameObject obj) {
        var currentPos = obj.transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x), Mathf.Round(currentPos.y), Mathf.Round(currentPos.z));
    }

    public bool IsDragging() {
        return dragging;
    }
}
