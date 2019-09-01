﻿using System.Collections;
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
        GameControl.instance.FindUI();
        Init();
    }

    private void Init() {
        //CreateGrid(GameControl.instance.gridSize);
        //CreateFireflies(GameControl.instance.fireflies);
        //CreateTargets(GameControl.instance.targetColors, GameControl.instance.targetLocations);

        CreateGrid(3);
        CreateFireflies(new List<ColorName>() { ColorName.RED, ColorName.BLUE, ColorName.RED });
        CreateTargets(new List<ColorName>() { ColorName.BLUE, ColorName.RED, ColorName.RED },
            new List<int>() { 2, 5, 7 });
    }

    //Resets firefly positions, removes all light
    public void Reset() {
        //Reset firefly position
        float yPos = 3f;
        foreach (Firefly firefly in fireflies) {
            firefly.gameObject.transform.localPosition = new Vector2(5, yPos);
            yPos -= 1.5f;
        }

        //Remove all light
        foreach (GridSpace space in spaces) {
            space.HideHorizontal();
            space.HideVertical();
        }

        //Reset all targets
        foreach (Target target in targets) {
            target.SetLight(false, Color.white);
        }
    }

    private void CreateGrid(int size) {
        this.size = size;
        spaces = new GridSpace[size * size];

        //Row
        float yPos = 4.5f - (9.0f / size / 2);
        for (int i = 0; i < size; i++) {
            float xPos = -4.5f + (9.0f / size / 2);

            //Col
            for (int j = 0; j < size; j++) {
                GameObject space = CreateSpace(i * size + j, xPos, yPos);
                spaces[i * size + j] = space.GetComponent<GridSpace>();
                xPos += 9.0f / size;
            }

            yPos -= 9.0f / size;
        }
    }

    private GameObject CreateSpace(int spaceNum, float xPos, float yPos) {
        GameObject space = Instantiate(gridSpace, gameObject.transform);

        space.transform.localScale = new Vector2(9f / size, 9f / size);
        space.transform.localPosition = new Vector2(xPos, yPos);
        space.name = spaceNum.ToString();

        return space;
    }

    private void CreateFireflies(List<ColorName> fireflyColors) {
        fireflies = new List<Firefly>();

        float yPos = 3f;
        foreach (ColorName fireflyColor in fireflyColors) {
            GameObject temp = CreateFirefly(fireflyColor, yPos);
            fireflies.Add(temp.GetComponent<Firefly>());
            yPos -= 1.5f;
        }
    }

    private GameObject CreateFirefly(ColorName fireflyColor, float yPos) {
        GameObject temp = Instantiate(firefly, GameObject.Find("Fireflies").transform);

        temp.transform.localPosition = new Vector2(5, yPos);
        temp.name = fireflyColor.ToString().ToLower();

        return temp;
    }

    private void CreateTargets(List<ColorName> targetColors, List<int> targetPositions) {
        targets = new List<Target>();

        for (int i = 0; i < targetPositions.Count; i++) {
            GameObject temp = CreateTarget(targetColors[i], targetPositions[i]);

            Target script = temp.GetComponent<Target>();
            targets.Add(script);
            script.SetColor();
            script.location = targetPositions[i];
        }
    }

    private GameObject CreateTarget(ColorName targetColor, int position) {
        GameObject temp = Instantiate(target, GameObject.Find("Targets").transform);
        
        temp.transform.localPosition = spaces[position].gameObject.transform.position;
        temp.name = targetColor.ToString().ToLower() + "Target";

        return temp;
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

        return IsSpaceOccupiedByTarget(space);
    }

    private bool IsSpaceOccupiedByTarget(int space) {
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

        Win();
    }
    
    private void Win() {
        GameObject.Find("GameControl").GetComponent<GameControl>().Win();

        foreach(Firefly firefly in fireflies) {
            firefly.Disable();
        }
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

            if (IsSpaceOccupiedByTarget(space)) {
                HideLeft(space);
                break;
            }

            HideHorizontal(space);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        for (int i = col - 1; i >= 0; i--) {
            int space = size * row + i;

            if (IsSpaceOccupiedByTarget(space)) {
                HideRight(space);
                break;
            }

            HideHorizontal(space);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        HideHorizontal(location);

        //Vertical
        for (int i = row + 1; i < size; i++) {
            int space = i * size + col;

            if (IsSpaceOccupiedByTarget(space)) {
                HideUp(space);
                break;
            }

            HideVertical(space);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        for (int i = row - 1; i >= 0; i--) {
            int space = i * size + col;

            if (IsSpaceOccupiedByTarget(space)) {
                HideDown(space);
                break;
            }

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

            if (IsSpaceOccupiedByTarget(space)) {
                ShowLeft(space, color);
                break;
            }
            
            ShowHorizontal(space, color);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        for (int i = col - 1; i >= 0; i--) {
            int space = size * row + i;

            if (IsSpaceOccupiedByTarget(space)) {
                ShowRight(space, color);
                break;
            }

            ShowHorizontal(space, color);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        ShowHorizontal(location, color);

        //Vertical
        for (int i = row + 1; i < size; i++) {
            int space = i * size + col;

            if (IsSpaceOccupiedByTarget(space)) {
                ShowUp(space, color);
                break;
            }

            ShowVertical(space, color);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        for (int i = row - 1; i >= 0; i--) {
            int space = i * size + col;

            if (IsSpaceOccupiedByTarget(space)) {
                ShowDown(space, color);
                break;
            }

            ShowVertical(space, color);
            if (IsSpaceOccupiedByFireflyOrTarget(space))
                break;
        }
        ShowVertical(location, color);

        UpdateTargets();
    }

    private void HideVertical(int space) {
        spaces[space].HideVertical();
    }

    private void HideHorizontal(int space) {
        spaces[space].HideHorizontal();
    }

    private void HideLeft(int space) {
        spaces[space].HideLeft();
    }

    private void HideRight(int space) {
        spaces[space].HideRight();
    }

    private void HideUp(int space) {
        spaces[space].HideUp();
    }

    private void HideDown(int space) {
        spaces[space].HideDown();
    }

    private void ShowVertical(int space, ColorName color) {
        spaces[space].ShowVertical(color);
    }

    private void ShowHorizontal(int space, ColorName color) {
        spaces[space].ShowHorizontal(color);
    }

    private void ShowLeft(int space, ColorName color) {
        spaces[space].ShowLeft(color);
    }

    private void ShowRight(int space, ColorName color) {
        spaces[space].ShowRight(color);
    }

    private void ShowUp(int space, ColorName color) {
        spaces[space].ShowUp(color);
    }

    private void ShowDown(int space, ColorName color) {
        spaces[space].ShowDown(color);
    }

    private void UpdateTargets() {
        foreach (Target target in targets) {
            target.SetLight(spaces[target.location].IsLit(), spaces[target.location].GetSpaceColor());
        }
    }
}
