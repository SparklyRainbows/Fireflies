using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject solvedPanel;
    public GameObject tutorialPanel;
    public GameObject pausePanel;
    public GameObject winPanel;

    private void Start() {
        if (GameControl.instance.level == 1)
            tutorialPanel.SetActive(true);
    }

    public void HideTutorial() {
        tutorialPanel.SetActive(false);
    }

    public void TogglePausePanel(bool active) {
        pausePanel.SetActive(active);
    }

    public void ShowWinPanel() {
        winPanel.SetActive(true);
    }

    public void ToggleSolvedPanel(bool active) {
        solvedPanel.SetActive(active);
    }
}
