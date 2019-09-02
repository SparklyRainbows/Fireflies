using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    List<Action> levelList;

    private void Start() {
        levelList = new List<Action>() {
            () => ThreeA(),
            () => ThreeB(),
            () => ThreeC(),
            () => FourA(),
            () => FourB(),
            () => FiveA(),
            () => SevenA()
        };
    }

    public void LoadNextLevel() {
        LoadLevel(GameControl.instance.level);
    }

    public void LoadLevelSelect() {
        SceneManager.LoadScene("LevelSelection");
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
		        Application.Quit ();
        #endif
    }

    public void LoadLevel(int level) {
        GameControl.instance.level = level;

        levelList[level - 1].Invoke();

        LoadLevel();
    }

    private void LoadLevel() {
        SceneManager.LoadScene("Level");
    }

    //---------------------

    private void ThreeA() {
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

    private void ThreeB() {
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

    private void ThreeC() {
        List<ColorName> fireflies = new List<ColorName>() {
            ColorName.RED,
            ColorName.YELLOW,
            ColorName.BLUE
        };

        List<ColorName> targetColors = new List<ColorName>() {
            ColorName.VIOLET,
            ColorName.BROWN,
            ColorName.GREEN
        };
        List<int> targetLocations = new List<int>() {
            2,
            3,
            8
        };

        GameControl.instance.LoadLevel(3, fireflies, targetColors, targetLocations);
    }

    private void FourA() {
        List<ColorName> fireflies = new List<ColorName>() {
            ColorName.RED,
            ColorName.YELLOW,
            ColorName.BLUE,
            ColorName.BLUE
        };

        List<ColorName> targetColors = new List<ColorName>() {
            ColorName.VIOLET,
            ColorName.BLUE,
            ColorName.GREEN
        };
        List<int> targetLocations = new List<int>() {
            6,
            8,
            15
        };

        GameControl.instance.LoadLevel(4, fireflies, targetColors, targetLocations);
    }

    private void FourB() {
        List<ColorName> fireflies = new List<ColorName>() {
            ColorName.ORANGE,
            ColorName.YELLOW,
            ColorName.BLUE,
            ColorName.VIOLET
        };

        List<ColorName> targetColors = new List<ColorName>() {
            ColorName.VIOLET,
            ColorName.BROWN,
            ColorName.GREEN,
            ColorName.ORANGE
        };
        List<int> targetLocations = new List<int>() {
            1,
            5,
            13,
            15
        };

        GameControl.instance.LoadLevel(4, fireflies, targetColors, targetLocations);
    }

    private void FiveA() {
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

    private void SevenA() {
        List<ColorName> fireflies = new List<ColorName>() {
            ColorName.RED,
            ColorName.ORANGE,
            ColorName.YELLOW,
            ColorName.GREEN,
            ColorName.BLUE,
            ColorName.BLUE,
            ColorName.VIOLET
        };

        List<ColorName> targetColors = new List<ColorName>() {
            ColorName.RED,
            ColorName.YELLOW,
            ColorName.VIOLET,
            ColorName.BLUE,
            ColorName.BROWN,
            ColorName.GREEN,
            ColorName.GREEN
        };
        List<int> targetLocations = new List<int>() {
            4,
            7,
            21,
            24,
            27,
            41,
            44
        };

        GameControl.instance.LoadLevel(7, fireflies, targetColors, targetLocations);
    }
}
