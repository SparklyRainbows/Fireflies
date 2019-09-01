using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance = null;

    public int level;

    [Header("Grid Info")]
    public int gridSize;
    public List<ColorName> fireflies;
    public List<ColorName> targetColors;
    public List<int> targetLocations;

    UI ui;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start() {
        level = 1;
    }

    public void FindUI() {
        ui = GameObject.Find("Canvas").GetComponent<UI>();
    }

    public void LoadLevel(int gridSize, List<ColorName> fireflies, List<ColorName> targetColors, List<int> targetLocations) {
        this.gridSize = gridSize;
        this.fireflies = fireflies;
        this.targetColors = targetColors;
        this.targetLocations = targetLocations;
    }

    public void Win() {
        ui.ShowPanel();
        level++;
    }
}
