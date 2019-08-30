using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public static Grid instance = null;

    public GameObject[] spaces;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    public void UpdateFirefly(string spaceName, GameObject firefly) {
        firefly.GetComponent<Firefly>().location = int.Parse(spaceName);
    }
}
