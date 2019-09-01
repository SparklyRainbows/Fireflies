using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void LoadNextLevel() {
        LoadLevel(GameControl.instance.level);
    }

    public void LoadLevel(int level) {
        GameControl.instance.level = level;

        switch(level) {
            case (1):
                LevelOne();
                break;
            case (2):
                LevelTwo();
                break;
            case (3):
                LevelThree();
                break;
            default:
                Debug.LogWarning($"Level not set up: level {level}");
                return;
        }

        LoadLevel();
    }

    private void LoadLevel() {
        SceneManager.LoadScene("Level");
    }

    //---------------------

    private void LevelOne() {
        List<ColorName> fireflies = new List<ColorName>() {
            ColorName.BLUE,
            ColorName.RED,
            ColorName.RED
        };

        List<ColorName> targetColors = new List<ColorName>() {
            ColorName.BLUE,
            ColorName.RED,
            ColorName.RED
        };
        List<int> targetLocations = new List<int>() {
            2,
            5,
            7
        };

        GameControl.instance.LoadLevel(3, fireflies, targetColors, targetLocations);
    }

    private void LevelTwo() {
        List<ColorName> fireflies = new List<ColorName>() {
            ColorName.BLUE,
            ColorName.BLUE,
            ColorName.RED
        };

        List<ColorName> targetColors = new List<ColorName>() {
            ColorName.BLUE,
            ColorName.VIOLET
        };
        List<int> targetLocations = new List<int>() {
            2,
            6
        };

        GameControl.instance.LoadLevel(3, fireflies, targetColors, targetLocations);
    }

    private void LevelThree() {
        List<ColorName> fireflies = new List<ColorName>() {
            ColorName.VIOLET,
            ColorName.RED,
            ColorName.BLUE,
            ColorName.BLUE,
            ColorName.YELLOW,
            ColorName.YELLOW
        };

        List<ColorName> targetColors = new List<ColorName>() {
            ColorName.VIOLET,
            ColorName.BLUE,
            ColorName.BROWN,
            ColorName.ORANGE,
            ColorName.YELLOW
        };
        List<int> targetLocations = new List<int>() {
            4,
            11,
            13,
            14,
            24
        };

        GameControl.instance.LoadLevel(5, fireflies, targetColors, targetLocations);
    }
}
