using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject solvedPanel;
    public GameObject tutorialPanel;

    private void Start() {
        solvedPanel.SetActive(false);

        if (GameControl.instance.level == 1)
            tutorialPanel.SetActive(true);
    }

    public void HideTutorial() {
        tutorialPanel.SetActive(false);
    }

    public void ShowPanel() {
        solvedPanel.SetActive(true);
    }
}
