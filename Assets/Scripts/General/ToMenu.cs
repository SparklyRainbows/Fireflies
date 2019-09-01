using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMenu : MonoBehaviour
{
    public void LoadMainMenu() {
        GameControl.instance.gameObject.GetComponent<SceneManagement>().LoadMainMenu();
    }
}
