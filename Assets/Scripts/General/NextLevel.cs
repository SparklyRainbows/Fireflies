using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public void LoadNextLevel() {
        GameControl.instance.gameObject.GetComponent<SceneManagement>().LoadNextLevel();
    }
}
