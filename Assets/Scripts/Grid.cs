using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid instance = null;

    public GridSpace[] spaces;
    public List<Firefly> fireflies;
    public List<Target> targets;

    int size;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    private void Start() {
        size = (int)Mathf.Sqrt(spaces.Length);
    }

    /// <summary>
    /// Returns if space is occupied by a firefly or lit by a light beam or occupied by a target
    /// </summary>
    public bool IsSpaceOccupied(int space) {
        foreach (Firefly firefly in fireflies) {
            if (firefly.location == space) {
                return true;
            }
        }
        
        foreach(Target target in targets) {
            if (target.location == space) {
                return true;
            }
        }

        return spaces[space].IsLit();
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
    
    //
    //++++++++++++++++++++++++++++
    //FIX ME
    //++++++++++++++++++++++++++++
    //
    public void HideGridColor(int location) {
        if (location < 0) {
            return;
        }

        int row = location / size;
        int col = location % size;
        for (int i = 0; i < size; i++) {
            HideHorizontal(size * row + i);
            HideVertical(i * size + col);
        }

        UpdateTargets();
    }

    private void ShowGridColor(ColorName color, int location) {
        int row = location / size;
        int col = location % size;
        for (int i = 0; i < size; i++) {
            ShowHorizontal(size * row + i, color);
            ShowVertical(i * size + col, color);
        }

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
