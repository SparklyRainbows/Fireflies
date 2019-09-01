using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject panel;

    private void Start() {
        panel.SetActive(false);
    }

    public void ShowPanel() {
        panel.SetActive(true);
    }
}
