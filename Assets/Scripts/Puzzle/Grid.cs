using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid instance = null;

    public GameObject gridSpace;
    public GameObject firefly;
    public GameObject target;

    GridSpace[] spaces;
    List<Firefly> fireflies;
    List<Target> targets;

    int size;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    private void Start() {
        GameControl gc = GameObject.Find("GameControl").GetComponent<GameControl>();

        size = gc.gridSize;
        CreateGrid();
        CreateFireflies();
        CreateTargets();
    }

    private void CreateGrid() {

    }

    private void CreateFireflies() {

    }

    private void CreateTargets() {

    }

    /// <summary>
    /// Returns if space is occupied by a firefly or lit by a light beam or occupied by a target
    /// </summary>
    public bool IsSpaceOccupied(int space) {
        
        return IsSpaceOccupiedByFireflyOrTarget(space) || spaces[space].IsLit();
    }

    private bool IsSpaceOccupiedByFireflyOrTarget(int space) {
        foreach (Firefly firefly in fireflies) {
            if (firefly.location == space) {
                return true;
            }
        }

        foreach (Target target in targets) {
            if (target.location == space) {
                return true;
            }
        }

        return false;
    }

    public void UpdateFireflyLocation(string spaceName, Firefly firefly) {
        firefly.location = int.Parse(spaceName);
        
        ShowGridColor(firefly.GetColorName(), firefly.location);

        CheckForWin();
    }

    private void CheckForWin() {
        //Check if each space is occupied by firefly, target, or light
        for (int i = 0; i < spaces.Length; i++) {
            if (!IsSpaceOccupied(i))
                return;
        }

        //Check if each target is lit correctly
        foreach (Target target in targets) {
            if (!target.IsLitCorrectly())
                return;
        }

        Debug.Log("you win");
    }
    
    public void HideGridColor(int location) {
        if (location < 0) {
            return;
        }

        int row = location / size;
        int col = location % size;

        //Horizontal
        for (int i = col + 1; i < size; i++) {
            int space = size * row + i;
            HideHorizontal(space);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        for (int i = col - 1; i >= 0; i--) {
            int space = size * row + i;
            HideHorizontal(space);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        HideHorizontal(location);

        //Vertical
        for (int i = row + 1; i < size; i++) {
            int space = i * size + col;
            HideVertical(space);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        for (int i = row - 1; i >= 0; i--) {
            int space = i * size + col;
            HideVertical(space);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        HideVertical(location);

        UpdateTargets();
    }

    private void ShowGridColor(ColorName color, int location) {
        int row = location / size;
        int col = location % size;

        //Horizontal
        for (int i = col + 1; i < size; i++) {
            int space = size * row + i;
            ShowHorizontal(space, color);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        for (int i = col - 1; i >= 0; i--) {
            int space = size * row + i;
            ShowHorizontal(space, color);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        ShowHorizontal(location, color);

        //Vertical
        for (int i = row + 1; i < size; i++) {
            int space = i * size + col;
            ShowVertical(space, color);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        for (int i = row - 1; i >= 0; i--) {
            int space = i * size + col;
            ShowVertical(space, color);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        ShowVertical(location, color);

        UpdateTargets();
    }

    private void ShowVertical(int space, ColorName color) {
        spaces[space].ShowVertical(color);
    }

    private void ShowHorizontal(int space, ColorName color) {
        spaces[space].ShowHorizontal(color);
    }

    private void HideVertical(int space) {
        spaces[space].HideVertical();
    }

    private void HideHorizontal(int space) {
        spaces[space].HideHorizontal();
    }

    private void UpdateTargets() {
        foreach (Target target in targets) {
            target.SetLight(spaces[target.location].IsLit(), spaces[target.location].GetSpaceColor());
        }
    }
}
