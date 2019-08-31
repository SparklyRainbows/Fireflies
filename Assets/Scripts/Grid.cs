using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid instance = null;

    public GridSpace[] spaces;
    public List<Firefly> fireflies;
    public List<Target> targets;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
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

        //Horizontal
        if (location < 3) {
            HideHorizontal(0);
            HideHorizontal(1);
            HideHorizontal(2);
        } else if (location < 6) {
            HideHorizontal(3);
            HideHorizontal(4);
            HideHorizontal(5);
        } else {
            HideHorizontal(6);
            HideHorizontal(7);
            HideHorizontal(8);
        }

        //Vertical
        if (location % 3 == 0) {
            HideVertical(0);
            HideVertical(3);
            HideVertical(6);
        } else if (location % 3 == 1) {
            HideVertical(1);
            HideVertical(4);
            HideVertical(7);
        } else {
            HideVertical(2);
            HideVertical(5);
            HideVertical(8);
        }

        UpdateTargets();
    }

    private void ShowGridColor(ColorName color, int location) {
        //Horizontal
        if (location < 3) {
            ShowHorizontal(0, color);
            ShowHorizontal(1, color);
            ShowHorizontal(2, color);
        } else if (location < 6) {
            ShowHorizontal(3, color);
            ShowHorizontal(4, color);
            ShowHorizontal(5, color);
        } else {
            ShowHorizontal(6, color);
            ShowHorizontal(7, color);
            ShowHorizontal(8, color);
        }

        //Vertical
        if (location % 3 == 0) {
            ShowVertical(0, color);
            ShowVertical(3, color);
            ShowVertical(6, color);
        } else if (location % 3 == 1) {
            ShowVertical(1, color);
            ShowVertical(4, color);
            ShowVertical(7, color);
        } else {
            ShowVertical(2, color);
            ShowVertical(5, color);
            ShowVertical(8, color);
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
