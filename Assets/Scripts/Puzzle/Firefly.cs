using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firefly : MonoBehaviour
{
    public int location = -1;
    MyColor myColor;

    float distance;
    bool dragging;

    bool canMove = true;

    bool snapped;

    Vector3 originalPos;

    Transform transform;

    private void Start() {
        SetColor();

        GetComponent<SpriteRenderer>().color = myColor.GetColor();

        transform = gameObject.transform;
    }

    public void Disable() {
        canMove = false;
    }

    private void SetColor() {
        switch(gameObject.name) {
            case ("red"):
                myColor = new MyColor(ColorName.RED);
                return;
            case ("blue"):
                myColor = new MyColor(ColorName.BLUE);
                return;
            case ("yellow"):
                myColor = new MyColor(ColorName.YELLOW);
                return;
            case ("violet"):
                myColor = new MyColor(ColorName.VIOLET);
                return;
            case ("orange"):
                myColor = new MyColor(ColorName.ORANGE);
                return;
            case ("green"):
                myColor = new MyColor(ColorName.GREEN);
                return;
            case ("brown"):
                myColor = new MyColor(ColorName.BROWN);
                return;
            default:
                Debug.LogWarning($"Firefly name not found: {gameObject.name}");
                return;
        }
    }

    private void OnMouseDown() {
        if (!canMove)
            return;

        snapped = false;

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

    private void OnTriggerExit2D(Collider2D collision) {
        location = -1;
    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (dragging || snapped)
            return;

        int space = int.Parse(collision.gameObject.name);

        if (location != space && Grid.instance.IsSpaceOccupied(space)) {
            transform.position = originalPos;
        } else {
            Snap(collision.gameObject);
            Grid.instance.UpdateFireflyLocation(collision.gameObject.name, gameObject.GetComponent<Firefly>());
        }
    }

    private void Snap(GameObject obj) {
        var currentPos = obj.transform.position;
        transform.position = new Vector3(currentPos.x, currentPos.y, currentPos.z);

        snapped = true;
    }

    public bool IsDragging() {
        return dragging;
    }

    public Color GetColor() {
        return myColor.GetColor();
    }

    public ColorName GetColorName() {
        return myColor.GetColorName();
    }
}
