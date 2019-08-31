using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public int gridSize;
    public List<ColorName> fireflies;
    public List<ColorName> targetColors;
    public List<int> targetLocations;

    public void LoadLevel(int gridSize, List<ColorName> fireflies, List<ColorName> targetColors, List<int> targetLocations) {
        this.gridSize = gridSize;
        this.fireflies = fireflies;
        this.targetColors = targetColors;
        this.targetLocations = targetLocations;
    }

    private void Awake() {
        DontDestroyOnLoad(gameObject);
    }
}
