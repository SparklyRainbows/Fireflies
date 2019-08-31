﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    GameControl gc;

    private void Start() {
        gc = GetComponent<GameControl>();
    }

    public void LoadLevel(int level) {
        switch(level) {
            case (1):
                LevelOne();
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

        gc.LoadLevel(3, fireflies, targetColors, targetLocations);
    }
}
