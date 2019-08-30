using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    float distance;
    bool dragging;

    Transform transform;

    private void Start() {
        transform = gameObject.transform;
    }

    private void OnMouseDown() {
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

        //Snap();
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (dragging)
            return;

        Snap(collision.gameObject);
    }

    private void Snap(GameObject obj) {
        var currentPos = obj.transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x),
                                     Mathf.Round(currentPos.y),
                                     Mathf.Round(currentPos.z));
    }

    private void Snap() {
        var currentPos = transform.position;
        transform.position = new Vector3(Mathf.Round(currentPos.x),
                                     Mathf.Round(currentPos.y),
                                     Mathf.Round(currentPos.z));
    }
}
